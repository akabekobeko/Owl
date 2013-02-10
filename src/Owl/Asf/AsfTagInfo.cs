
namespace Owl.Asf
{
	/// <summary>
	/// タグ情報を表します。
	/// </summary>
	public sealed class AsfTagInfo
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="headerObject">タグの所属する ASF オブジェクト。</param>
		/// <param name="type">データ種別。</param>
		/// <param name="name">名前。</param>
		/// <param name="canEdit">編集可能なら true。それ以外は false。</param>
		internal AsfTagInfo( string name, AsfTagDataType type, bool canEdit, HeaderObjectType headerObject )
		{
			this.HeaderObject = headerObject;
			this.Name         = name;
			this.Type         = type;
			this.CanEdit      = canEdit;

		}

		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="name">名前。</param>
		/// <param name="type">データ種別。</param>
		/// <param name="canEdit">編集可能なら true。それ以外は false。</param>
		internal AsfTagInfo( string name, AsfTagDataType type, bool canEdit )
			: this( name, type, canEdit, HeaderObjectType.Unknown )
		{
		}

		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="name">名前。</param>
		/// <param name="type">データ種別。</param>
		internal AsfTagInfo( string name, AsfTagDataType type )
			: this( name, type, false )
		{
		}

		/// <summary>
		/// タグが編集可能であることを示す値を取得します。
		/// </summary>
		public bool CanEdit { get; private set; }

		/// <summary>
		/// タグ値のデータ型を取得します。
		/// </summary>
		public AsfTagDataType Type { get; private set; }

		/// <summary>
		/// 所属する ASF オブジェクトの種別を取得します。
		/// </summary>
		internal HeaderObjectType HeaderObject { get; private set; }

		/// <summary>
		/// 名前を取得します。
		/// </summary>
		internal string Name { get; private set; }
	}
}
