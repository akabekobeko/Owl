using System;
using System.IO;
using Owl.Asf;

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
			if( src == null || src.Length == 0 ) { throw new ArgumentException( "'src' is null or empty." ); }

			if( AsfTagEditor.IsSupportedFile( src ) )
			{
				this._editor = new AsfTagEditor( src );
			}
			else
			{
				throw new NotSupportedException();
			}
		}

		/// <summary>
		/// リソースを破棄します。
		/// </summary>
		public void Dispose()
		{
			if( this._editor != null )
			{
				this._editor.Dispose();
				this._editor = null;
			}

			GC.SuppressFinalize( this );
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		public bool HasValue( TagInfo tag )
		{
			return this._editor.HasValue( tag );
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		public object Read( TagInfo tag )
		{
			return this._editor.Read( tag );
		}

		/// <summary>
		/// 編集内容を保存します。
		/// </summary>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( Stream dest )
		{
			this._editor.Save( dest );
		}

		/// <summary>
		/// タグ情報を書き込みます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		public void Write( TagInfo tag, object value )
		{
			this._editor.Write( tag, value );
		}

		/// <summary>
		/// タグ情報を編集するためのオブジェクト。
		/// </summary>
		private ITagEditor _editor;
	}
}
