
namespace Owl
{
	/// <summary>
	/// タグ情報を表します。
	/// </summary>
	public class TagInfo
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="type">データ型。</param>
		/// <param name="canEdit">編集可能な値ならば true。それ以外は false。</param>
		internal TagInfo( TagDataType type, bool canEdit )
		{
			this.Type = type;
			this.CanEdit = canEdit;
		}

		/// <summary>
		/// タグが編集可能であることを示す値を取得します。
		/// </summary>
		public bool CanEdit { get; private set; }

		/// <summary>
		/// タグ値のデータ型を取得します。
		/// </summary>
		public TagDataType Type { get; private set; }
	}
}
