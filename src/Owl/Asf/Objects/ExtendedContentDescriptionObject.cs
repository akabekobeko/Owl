using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Owl.Utilities;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// Extended Content Description Object を表します。
	/// </summary>
	sealed class ExtendedContentDescriptionObject : IAsfObject
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="src">オブジェクト情報を読み取るストリーム。位置はオブジェクトのボディ先頭 ( サイズ情報の直後 ) に設定します。新規作成なら null を指定します。</param>
		/// <param name="size">オブジェクトのサイズ。</param>
		public ExtendedContentDescriptionObject( Stream src, long size )
		{
			if( src == null )
			{
				// 新規作成の場合はヘッダ + タグ総数を初期サイズとしておく
				this.Size = ObjectHeader.ClassByteSize + 2;
			}
			else
			{
				this.Size = size;
				this.Load( src );
			}
		}

		/// <summary>
		/// タグ全体のサイズを算出します。
		/// </summary>
		/// <param name="name">タグの名前。</param>
		/// <param name="value">タグ情報。</param>
		/// <returns>サイズ。</returns>
		private static long CalcTagSize( string name, ObjectTagValue value )
		{
			// 名前の長さ ( 2 byte ) + 名前 + 値の型 ( 2 byte ) + 値の長さ ( 2 byte ) + 値 
			var nameLength = Encoding.Unicode.GetByteCount( String.Concat( name, "\0" ) );
			return 2 + nameLength + 2 + 2 + value.Length;
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		public bool HasValue( AsfTagInfo tag )
		{
			return this._tags.ContainsKey( tag.Name );
		}

		/// <summary>
		/// ストリームからタグ情報を読み込みます。
		/// </summary>
		/// <param name="src">オブジェクト情報を読み取るストリーム。位置はオブジェクトのボディ先頭 ( サイズ情報の直後 ) に設定します。</param>
		private void Load( Stream src )
		{
			var count = src.ReadUInt16();
			for( ushort i = 0; i < count; ++i )
			{
				// 設定
				var length = src.ReadUInt16();
				var name   = BinaryUtility.BytesUtf16StringToString( src.ReadBytes( length ) );
				var type   = ( ObjectTagValueType )src.ReadUInt16();

				// 値
				length = src.ReadUInt16();
				this._tags.Add( name, new ObjectTagValue( type, src.Position, length ) );
				src.Seek( length, SeekOrigin.Current );
			}
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="src">情報を読み取るストリーム。</param>
		/// <param name="tag">タグ。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		/// <exception cref="NotSupportedException">未サポートの操作です。</exception>
		public object Read( Stream src, AsfTagInfo tag )
		{
			if( tag == null ) { throw new ArgumentNullException( "tag" ); }

			ObjectTagValue data;
			return ( this._tags.TryGetValue( tag.Name, out data ) ? data.Read( tag.Type, src ) : null );
		}

		/// <summary>
		/// 編集内容を保存します
		/// </summary>
		/// <param name="src">情報を読み取るストリーム。</param>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( Stream src, Stream dest )
		{
			// ヘッダ
			{
				var guid = ExtendedContentDescriptionObject.Id.ToByteArray();
				dest.Write( guid, 0, guid.Length );

				var objectSize = BitConverter.GetBytes( ( ulong )this.Size );
				dest.Write( objectSize, 0, objectSize.Length );
			}

			// タグ総数
			{
				var b = BitConverter.GetBytes( ( ushort )this._tags.Count );
				dest.Write( b, 0, b.Length );
			}

			// タグ
			foreach( var tag in this._tags )
			{
				// 名前の長さ ( 2 byte ) + 名前 + 値の型 ( 2 byte ) + 値の長さ ( 2 byte ) + 値 
				var name = StringToBytes( tag.Key );
				dest.Write( BitConverter.GetBytes( ( ushort )name.Length ), 0, 2 );
				dest.Write( name, 0, name.Length );
				dest.Write( BitConverter.GetBytes( ( ushort )tag.Value.Type ), 0, 2 );
				dest.Write( BitConverter.GetBytes( ( ushort )tag.Value.Length ), 0, 2 );
				dest.Write( ( byte[] )tag.Value.Read( AsfTagDataType.Binary, src ), 0, tag.Value.Length );
			}
		}

		/// <summary>
		/// 文字列を NULL 文字終端の UTF-16LE バイト配列に変換します。
		/// </summary>
		/// <param name="str">文字列。</param>
		/// <returns>バイト配列。</returns>
		private static byte[] StringToBytes( string str )
		{
			return Encoding.Unicode.GetBytes( String.Concat( str, "\0" ) );
		}

		/// <summary>
		/// タグ情報を書き込みます。
		/// 既存のタグがなければ追加、ある場合は更新をおこないます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		/// <exception cref="ArgumentNullException">tag が null 参照です。</exception>
		/// <exception cref="NotSupportedException">指定されたタグは読み取り専用です。</exception>
		public void Write( AsfTagInfo tag, object value )
		{
			if( tag == null  ) { throw new ArgumentNullException( "tag" ); }
			if( !tag.CanEdit ) { throw new NotSupportedException( "Tag is read-only." ); }

			if( value == null )
			{
				// 削除
				ObjectTagValue tagValue;
				if( this._tags.TryGetValue( tag.Name, out tagValue ) )
				{
					this.Size -= CalcTagSize( tag.Name, tagValue );
					this._tags.Remove( tag.Name );
				}
			}
			else
			{
				ObjectTagValue tagValue;
				if( this._tags.TryGetValue( tag.Name, out tagValue ) )
				{
					// 更新
					this.Size -= CalcTagSize( tag.Name, tagValue );
					tagValue = new ObjectTagValue( tag.Type, value );
					this.Size += CalcTagSize( tag.Name, tagValue );
					this._tags[ tag.Name ] = tagValue;
				}
				else
				{
					// 追加
					tagValue = new ObjectTagValue( tag.Type, value );
					this.Size += CalcTagSize( tag.Name, tagValue );
					this._tags.Add( tag.Name, tagValue );
				}
			}
		}

		/// <summary>
		/// オブジェクトのサイズを取得します。
		/// </summary>
		public long Size { get; private set; }

		/// <summary>
		/// オブジェクトの識別子です。
		/// </summary>
		public static readonly Guid Id = new Guid( "D2D0A440-E307-11D2-97F0-00A0C95EA850" );

		/// <summary>
		/// タグ名をキーとする、タグ情報のディクショナリ。
		/// </summary>
		private Dictionary< string, ObjectTagValue > _tags = new Dictionary< string, ObjectTagValue >();

	}
}
