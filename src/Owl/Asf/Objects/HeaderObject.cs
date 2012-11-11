using System;
using System.IO;
using System.Collections.Generic;

namespace Owl.Asf
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
		public HeaderObject( Stream src )
		{

		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		public bool HasValue( AsfTagInfo tag )
		{
			throw new NotImplementedException();
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
		/// ASF オブジェクトのディクショナリ。
		/// </summary>
		private Dictionary< HeaderObjectType, IAsfObject > _objects = new Dictionary< HeaderObjectType, IAsfObject >();

		/// <summary>
		/// Header Object の識別子です。
		/// </summary>
		public static readonly Guid Id = new Guid( "75B22630-668E-11CF-A6D9-00AA0062CE6C" );
	}
}
