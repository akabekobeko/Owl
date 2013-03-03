using System;
using System.IO;
using System.Collections.Generic;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// ASF の Header Object を表します。
	/// </summary>
	sealed class HeaderObject
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
			this._src = src;
			this._src.Seek( 0, SeekOrigin.Begin );

			// ASF ファイルであることをチェック
			{
				var info = new ObjectHeader( this._src );
				if( info.Guid != HeaderObject.Id ) { throw new NotSupportedException( "ASF file format is not." ); }

				this.Size = info.Size;
			}

			// 子オブジェクト総数と Reserved 1、2 を取得
			var count = this._src.ReadInt32();
			this._src.Read( this._reserved, 0, 2 );

			// オブジェクト読み取り
			for( var i = 0; i < count; ++i )
			{
				var objectBegin  = this._src.Position;
				var objectHeader = new ObjectHeader( this._src );

				if( objectHeader.Guid == FilePropertiesObject.Id )
				{
					this._objects.Add( HeaderObjectType.FileProperties, new FilePropertiesObject( this._src ) );
				}
				else if( objectHeader.Guid == ContentDescriptionObject.Id )
				{
					this._objects.Add( HeaderObjectType.ContentDescription, new ContentDescriptionObject( this._src, objectHeader.Size ) );
				}
				else
				{
					this._unknowns.Add( new UnknownObject( this._src, objectHeader ) );
				}

				// 次のオブジェクト始点へ移動
				this._src.Seek( objectBegin + objectHeader.Size, SeekOrigin.Begin );
			}
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		/// <exception cref="ArgumentNullException">tag が null 参照です。</exception>
		public bool HasValue( AsfTagInfo tag )
		{
			if( tag == null ) { throw new ArgumentNullException( "'tag' is null." ); }

			IAsfObject asfObject;
			return ( this._objects.TryGetValue( tag.HeaderObject, out asfObject ) ? asfObject.HasValue( tag ) : false );
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="src">情報を読み取るストリーム。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		/// <exception cref="ArgumentNullException">tag が null 参照です。</exception>
		public object Read( AsfTagInfo tag )
		{
			if( tag == null ) { throw new ArgumentNullException( "'tag' is null." ); }

			IAsfObject obj;
			return ( this._objects.TryGetValue( tag.HeaderObject, out obj ) ? obj.Read( this._src, tag ) : null );
		}

		/// <summary>
		/// 編集内容を保存します
		/// </summary>
		/// <param name="dest">保存先となるストリーム。</param>
		/// <exception cref="ArgumentNullException">dest が null 参照です。</exception>
		public void Save( Stream dest )
		{
			if( dest == null ) { throw new ArgumentNullException( "'dest' is null." ); }

			dest.Seek( 0, SeekOrigin.Begin );
			dest.Write( HeaderObject.Id.ToByteArray(), 0, 16 );
			dest.Write( BitConverter.GetBytes( ( ulong )this.Size ), 0, 8 );
			dest.Write( BitConverter.GetBytes( ( uint )( this._objects.Count + this._unknowns.Count ) ), 0, 4 );
			dest.Write( this._reserved, 0, 2 );

			foreach( var obj in this._objects.Values )
			{
				obj.Save( this._src, dest );
			}

			foreach( var obj in this._unknowns )
			{
				obj.Save( this._src, dest );
			}
		}

		/// <summary>
		/// タグ情報を書き込みます。
		/// 既存のタグがなければ追加、ある場合は更新をおこないます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		public void Write( AsfTagInfo tag, object value )
		{
			IAsfObject obj;
			if( this._objects.TryGetValue( tag.HeaderObject, out obj ) )
			{
				var old = obj.Size;
				obj.Write( tag, value );

				var size = obj.Size - old;
				this.Size += size;

				// ファイル サイズを更新
				var file = this._objects[ HeaderObjectType.FileProperties ] as FilePropertiesObject;
				file.FileSize += ( ulong )( size );
			}
		}

		/// <summary>
		/// オブジェクトのサイズを取得します。
		/// </summary>
		public long Size { get; private set; }

		/// <summary>
		/// ASF タグ情報の読み取り元ストリーム。
		/// </summary>
		private Stream _src;

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
