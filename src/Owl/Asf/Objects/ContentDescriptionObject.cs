using System;
using System.Collections.Generic;
using System.IO;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// Content Description Object を表します。
	/// </summary>
	class ContentDescriptionObject : IAsfObject
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="src">オブジェクト情報を読み取るストリーム。位置はオブジェクトのボディ先頭 ( サイズ情報の直後 ) に設定します。新規作成なら null を指定します。</param>
		public ContentDescriptionObject( Stream src )
		{
			if( src == null )
			{
				// 新規作成の場合はヘッダ + 値サイズ ( 2 byte x 必須タグの数 ) を初期サイズとしておく
				this.Size = ObjectHeader.ClassByteSize + ( 2 * ContentDescriptionObject.RequiredTagCount );
			}
			else
			{
				this._src = src;
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
		/// オブジェクトのデータ構造は以下のようになります。
		///
		///   1.タグのサイズ ( 2byte )  x タグ数
		///   2.タグの内容 ( サイズ分 ) x タグ数
		///
		/// よって、はじめにサイズを読み、次にその分だけ値を取得してゆきます。
		/// </summary>
		/// <param name="src">オブジェクト情報を読み取るストリーム。位置はオブジェクトのボディ先頭 ( サイズ情報の直後 ) に設定します。</param>
		private void Load( Stream src )
		{
			var length = new int[ ContentDescriptionObject.RequiredTagCount ] { src.ReadInt16(), src.ReadInt16(), src.ReadInt16(), src.ReadInt16(), src.ReadInt16() };
			var names  = ContentDescriptionObject.GetRequiredTagNames();

			for( var i = 0; i < ContentDescriptionObject.RequiredTagCount; ++i )
			{
				this._tags.Add( names[ i ], new ObjectTagValue( ObjectTagValueType.String, this._src.Position, length[ i ] ) );
				this._src.Seek( length[ i ], SeekOrigin.Current );
			}
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		public object Read( AsfTagInfo tag )
		{
			if( tag == null ) { throw new ArgumentNullException( "tag" ); }

			ObjectTagValue value;
			return ( this._tags.TryGetValue( tag.Name, out value ) ? value.Read( tag.Type, this._src ) : null );
		}

		/// <summary>
		/// 必須タグの名前情報コレクションを取得します。
		/// </summary>
		/// <returns>名前情報コレクション。</returns>
		private static string[] GetRequiredTagNames()
		{
			return new string[ ContentDescriptionObject.RequiredTagCount ]
			{
				AsfTags.Title.Name,
				AsfTags.Author.Name,
				AsfTags.Copyright.Name,
				AsfTags.Description.Name,
				AsfTags.Rating.Name
			};
		}

		/// <summary>
		/// 編集内容を保存します
		/// </summary>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( Stream dest )
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
		/// <exception cref="NotSupportedException">指定されたタグは編集をサポートしていません。</exception>
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
					this.Size -= tagValue.Length;
					this._tags.Remove( tag.Name );
				}
			}
			else
			{
				// 更新と追加
				ObjectTagValue tagValue;
				if( this._tags.TryGetValue( tag.Name, out tagValue ) )
				{
					// 更新
					this.Size -= tagValue.Length;
					tagValue = new ObjectTagValue( tag.Type, value );
					this.Size += tagValue.Length;
					this._tags[ tag.Name ] = tagValue;
				}
				else
				{
					// 追加
					tagValue = new ObjectTagValue( tag.Type, value );
					this.Size += tagValue.Length;
					this._tags.Add( tag.Name, tagValue );
				}
			}
		}

		/// <summary>
		/// オブジェクトのサイズを取得します。
		/// </summary>
		public long Size { get; private set; }

		/// <summary>
		/// オブジェクト情報を読み取るストリーム。
		/// </summary>
		private Stream _src;

		/// <summary>
		/// タグ名をキーとする、タグ値のディクショナリ。
		/// </summary>
		private Dictionary< string, ObjectTagValue > _tags = new Dictionary< string, ObjectTagValue >( ContentDescriptionObject.RequiredTagCount );

		/// <summary>
		/// オブジェクトの識別子です。
		/// </summary>
		public static readonly Guid Id = new Guid( "75B22633-668E-11CF-A6D9-00AA0062CE6C" );

		/// <summary>
		/// オブジェクトに必須となるタグ数。
		/// </summary>
		private const int RequiredTagCount = 5;
	}
}
