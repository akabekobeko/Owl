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
			throw new NotImplementedException();
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
			throw new NotImplementedException();
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
