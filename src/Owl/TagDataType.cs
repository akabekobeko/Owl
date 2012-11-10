
namespace Owl
{
	/// <summary>
	/// タグの内容となるデータ型を表します。
	/// </summary>
	public enum TagDataType
	{
		/// <summary>
		/// 文字列。
		/// </summary>
		String,

		/// <summary>
		/// バイト配列。
		/// </summary>
		Binary,

		/// <summary>
		/// 真偽値。
		/// </summary>
		Bool,

		/// <summary>
		/// 符号付き 16 ビット整数。
		/// </summary>
		Int16,

		/// <summary>
		/// 符号付き 32 ビット整数。
		/// </summary>
		Int32,

		/// <summary>
		/// 符号付き 64 ビット整数。
		/// </summary>
		Int64,

		/// <summary>
		/// 符号なし 16 ビット整数。
		/// </summary>
		UInt16,

		/// <summary>
		/// 符号なし 32 ビット整数。
		/// </summary>
		UInt32,

		/// <summary>
		/// 符号なし 64 ビット整数。
		/// </summary>
		UInt64,

		/// <summary>
		/// 時間。
		/// </summary>
		TimeSpan,

		/// <summary>
		/// 日時。
		/// </summary>
		DateTime,

		/// <summary>
		/// GUID。
		/// </summary>
		Guid,

		/// <summary>
		/// 画像。
		/// </summary>
		Picture
	}
}
