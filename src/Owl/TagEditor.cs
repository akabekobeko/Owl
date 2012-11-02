using System;
using System.IO;

namespace Owl
{
	/// <summary>
	/// メタデータのタグを編集します。
	/// </summary>
	public class TagEditor : ITagEditor
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="src">編集対象とするメタデータのストリーム。</param>
		/// <exception cref="NotSupportedException">src にサポートされていない形式のデータが指定されました。</exception>
		public TagEditor( Stream src )
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		public void Dispose()
		{
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		public bool HasValue( TagInfo tag )
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		public object Read( TagInfo tag )
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// 編集内容を保存します。
		/// </summary>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( System.IO.Stream dest )
		{
			throw new System.NotImplementedException();
		}

		/// <summary>
		/// タグ情報を書き込みます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		public void Write( TagInfo tag, object value )
		{
			throw new System.NotImplementedException();
		}
	}
}
