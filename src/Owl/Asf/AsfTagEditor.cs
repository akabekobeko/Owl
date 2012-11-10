using System;

namespace Owl.Asf
{
	/// <summary>
	/// ASF のメタデータ タグを編集します。
	/// </summary>
	public sealed class AsfTagEditor : ITagEditor
	{
		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		public void Dispose()
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		public bool HasValue( TagInfo tag )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		public object Read( TagInfo tag )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// 編集内容を保存します。
		/// </summary>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( System.IO.Stream dest )
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// タグ情報を書き込みます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		public void Write( TagInfo tag, object value )
		{
			throw new NotImplementedException();
		}

	}
}
