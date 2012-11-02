using System;
using System.IO;

namespace Owl
{
	/// <summary>
	/// メタデータのタグを編集するための基本的なインターフェースです。
	/// </summary>
	public interface ITagEditor : IDisposable
	{
		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		bool HasValue( TagInfo tag );

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		object Read( TagInfo tag );

		/// <summary>
		/// 編集内容を保存します。
		/// </summary>
		/// <param name="dest">保存先となるストリーム。</param>
		void Save( Stream dest );

		/// <summary>
		/// タグ情報を書き込みます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		void Write( TagInfo tag, object value );
	}
}
