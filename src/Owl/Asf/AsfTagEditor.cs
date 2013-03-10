using System;
using System.IO;
using Owl.Asf.Objects;
using System.Diagnostics;

namespace Owl.Asf
{
	/// <summary>
	/// ASF のメタデータ タグを編集します。
	/// </summary>
	public sealed class AsfTagEditor : ITagEditor
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="src">ASF ファイルのストリーム。</param>
		/// <exception cref="NotSupportedException">src の指す対象が ASF 形式ではありません。</exception>
		public AsfTagEditor( Stream src )
		{
			this._header       = new HeaderObject( src );
			this._bodyPosition = this._header.Size;
			this._src          = src;
		}

		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		public void Dispose()
		{
			if( this._src != null )
			{
				this._src.Dispose();
				this._src = null;
			}

			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// 指定されたファイルがサポート対象の形式であることを調べます。
		/// </summary>
		/// <param name="src">ストリーム。</param>
		/// <returns>サポート対象なら true。それ以外は false。</returns>
		public static bool IsSupportedFile( Stream src )
		{
			try
			{
				var pos = src.Position;
				src.Seek( 0, SeekOrigin.Begin );

				var info = new ObjectHeader( src );
				src.Seek( pos, SeekOrigin.Begin );

				return ( info.Guid == HeaderObject.Id );
			}
			catch( Exception e )
			{
				Debug.WriteLine( e.Message );
				return false;
			}
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		public bool HasValue( TagInfo tag )
		{
			var asfTag = AsfTags.GetInfo( tag );
			return ( asfTag == null ? false : this._header.HasValue( asfTag ) );
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		public object Read( TagInfo tag )
		{
			var value = this._header.Read( AsfTags.GetInfo( tag ) );
			if( value == null ) { return null; }

			// 値の変換
			if( tag == Tags.BeatsPerMinute )
			{
				int v;
				int.TryParse( value as string, out v );
				return v;
			}
			else if( tag == Tags.Duration )
			{
				return new TimeSpan( ( long )( ulong )value );
			}
			else if( tag == Tags.EncodingTime )
			{
				return new DateTime( ( long )( ulong )value );
			}
			else if( tag == Tags.FileSize )
			{
				return ( long )( ulong )value;
			}
			else if( tag == Tags.OriginalReleaseDate || tag == Tags.ReleaseDate )
			{
				int v;
				return ( int.TryParse( value as string, out v ) ? new DateTime( v, 1, 1 ) : new DateTime() );
			}
			else if( tag == Tags.Picture )
			{
				// TODO: 画像は未対応
				return null;
			}
			else if( tag == Tags.TrackNumber )
			{
				// トラック番号は文字列と整数のパターンがあるので、両対応しておく
				int v;
				return ( value is int ? value : int.TryParse( value as string, out v ) ? ( int )v : 0 );
			}
			else
			{
				return value;
			}
		}

		/// <summary>
		/// 編集内容を保存します。
		/// </summary>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( Stream dest )
		{
			// ヘッダ
			this._header.Save( dest );
			this._src.Seek( this._bodyPosition, SeekOrigin.Begin );

			// ボディ
			var size = ( int )( this._src.Length - this._src.Position );
			var buffer = new byte[ AsfTagEditor.BufferSize ];
			do
			{
				var read = this._src.Read( buffer, 0, ( size > AsfTagEditor.BufferSize ? AsfTagEditor.BufferSize : size ) );
				dest.Write( buffer, 0, read );
				size -= read;

			} while( size > 0 );
		}

		/// <summary>
		/// タグ情報を書き込みます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		public void Write( TagInfo tag, object value )
		{
			if( tag == null ) { throw new ArgumentNullException( "tag" ); }

			// 削除
			var asfTag = AsfTags.GetInfo( tag );
			if( value == null )
			{
				this._header.Write( asfTag, value );
				return;
			}

			// 値の変換
			object writeValue = null;
			if( tag == Tags.BeatsPerMinute || tag == Tags.TrackNumber )
			{
				writeValue = ( ( int )value ).ToString();
			}
			else if( tag == Tags.Duration )
			{
				writeValue = ( ( TimeSpan )value ).Ticks;
			}
			else if( tag == Tags.EncodingTime )
			{
				writeValue = ( ( DateTime )value ).Ticks;
			}
			else if( tag == Tags.FileSize )
			{
				writeValue = ( ulong )( long )value;
			}
			else if( tag == Tags.OriginalReleaseDate || tag == Tags.ReleaseDate )
			{
				writeValue = ( ( DateTime )value ).Year.ToString();
			}
			else if( tag == Tags.Picture )
			{
				// TODO: 画像は未対応
			}

			// 変換した値を書き込む
			this._header.Write( asfTag, writeValue );
		}

		/// <summary>
		/// 編集がおこなわれたことを示す値を取得します。
		/// </summary>
		public bool IsEdited { get; private set; }

		/// <summary>
		/// ASF の Header Object。
		/// </summary>
		private HeaderObject _header;

		/// <summary>
		/// 元の ASF ファイル ストリームにおける、Header Object 以降のデータが開始される位置。
		/// </summary>
		private long _bodyPosition;

		/// <summary>
		/// タグ情報を持つストリーム。
		/// </summary>
		private Stream _src;

		/// <summary>
		/// データ保存時のバッファ サイズ。
		/// </summary>
		private static readonly int BufferSize = 1024;
	}
}
