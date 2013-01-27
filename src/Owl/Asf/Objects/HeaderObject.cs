using System;
using System.IO;
using System.Collections.Generic;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// ASF の Header Object を表します。
	/// </summary>
	internal class HeaderObject : IAsfObject
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="src">ASF 形式のデータ ストリーム。</param>
		/// <exception cref="ArgumentNullException">src が null 参照です。</exception>
		/// <exception cref="NotSupportedException">src の内容が ASF 形式ではありません。</exception>
		public HeaderObject( Stream src )
		{
			// 現在は新規作成をサポートせず、必ずストリーム先頭に ASF の HeaderObject が格納されていることを前提とする
			if( src == null ) { throw new ArgumentNullException( "'src' is null." ); }
			src.Seek( 0, SeekOrigin.Begin );

			// ASF ファイルであることをチェック
			{
				var info = new ObjectHeader( src );
				if( info.Guid != HeaderObject.Id ) { throw new NotSupportedException( "ASF file format is not." ); }

				this.Size = info.Size;
			}

			// 子オブジェクト総数と Reserved 1、2 を取得
			var count = src.ReadInt32();
			src.Read( this._reserved, 0, 2 );

			// オブジェクト読み取り
			for( var i = 0; i < count; ++i )
			{
				var objectBegin  = src.Position;
				var objectHeader = new ObjectHeader( src );

				if( FilePropertiesObject.Id == objectHeader.Guid )
				{
					this._objects.Add( HeaderObjectType.FileProperties, new FilePropertiesObject( src ) );
				}
				else
				{
					this._unknowns.Add( new UnknownObject( src, objectHeader ) );
				}

				// 次のオブジェクト始点へ移動
				src.Seek( objectBegin + objectHeader.Size, SeekOrigin.Begin );
			}
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		public bool HasValue( AsfTagInfo tag )
		{
			IAsfObject asfObject;
			return ( this._objects.TryGetValue( tag.HeaderObject, out asfObject ) ? asfObject.HasValue( tag ) : false );
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="src">情報を読み取るストリーム。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		public object Read( AsfTagInfo tag, System.IO.Stream src )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 編集内容を保存します
		/// </summary>
		/// <param name="src">タグ情報の読み出し元となるストリーム。</param>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( System.IO.Stream src, System.IO.Stream dest )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// タグ情報を書き込みます。
		/// 既存のタグがなければ追加、ある場合は更新をおこないます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		public void Write( AsfTagInfo tag, object value )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// オブジェクトのサイズを取得します。
		/// </summary>
		public long Size { get; private set; }

		/// <summary>
		/// オブジェクト種別をキーとする、子オブジェクトのディクショナリ。
		/// </summary>
		private Dictionary< HeaderObjectType, IAsfObject > _objects = new Dictionary< HeaderObjectType, IAsfObject >();

		/// <summary>
		/// 未知の子オブジェクトのコレクション。
		/// </summary>
		private List< UnknownObject > _unknowns = new List< UnknownObject >();

		/// <summary>
		/// Header Object の予約済み領域。
		/// </summary>
		private byte[] _reserved = new byte[ 2 ];

		/// <summary>
		/// Header Object の識別子です。
		/// </summary>
		public static readonly Guid Id = new Guid( "75B22630-668E-11CF-A6D9-00AA0062CE6C" );
	}
}
