
namespace Owl.Asf
{
	/// <summary>
	/// タグ情報を表します。
	/// </summary>
	public sealed class AsfTagInfo : TagInfo
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="headerObject">タグの所属する ASF オブジェクト。</param>
		/// <param name="type">データ種別。</param>
		/// <param name="name">名前。</param>
		/// <param name="canEdit">編集可能なら true。それ以外は false。</param>
		internal AsfTagInfo( string name, TagDataType type, bool canEdit, HeaderObjectType headerObject )
			: base( type, canEdit )
		{
			this.HeaderObject = headerObject;
			this.Name         = name;
		}

		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="name">名前。</param>
		/// <param name="type">データ種別。</param>
		/// <param name="canEdit">編集可能なら true。それ以外は false。</param>
		internal AsfTagInfo( string name, TagDataType type, bool canEdit )
			: this( name, type, canEdit, HeaderObjectType.Unknown )
		{
		}

		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="name">名前。</param>
		/// <param name="type">データ種別。</param>
		internal AsfTagInfo( string name, TagDataType type )
			: this( name, type, false )
		{
		}

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
