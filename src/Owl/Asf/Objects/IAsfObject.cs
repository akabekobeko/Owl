using System;
using System.IO;

namespace Owl.Asf
{
	/// <summary>
	/// ASF のオブジェクトを表します。
	/// </summary>
	internal interface IAsfObject
	{
		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		bool HasValue( AsfTagInfo tag );

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="src">情報を読み取るストリーム。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		object Read( AsfTagInfo tag, Stream src );

		/// <summary>
		/// 編集内容を保存します
		/// </summary>
		/// <param name="src">タグ情報の読み出し元となるストリーム。</param>
		/// <param name="dest">保存先となるストリーム。</param>
		void Save( Stream src, Stream dest );

		/// <summary>
		/// タグ情報を書き込みます。
		/// 既存のタグがなければ追加、ある場合は更新をおこないます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		void Write( AsfTagInfo tag, object value );

		/// <summary>
		/// オブジェクトのサイズを取得します。
		/// </summary>
		long Size { get; }
	}
}
