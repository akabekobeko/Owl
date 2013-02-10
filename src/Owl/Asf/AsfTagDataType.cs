
namespace Owl.Asf
{
	/// <summary>
	/// タグ情報の型を定義します。
	/// 各値の実数は Windows Media Format の WMT_ATTR_DATATYPE に対応しています。
	/// </summary>
	public enum AsfTagDataType
	{
		/// <summary>
		/// 符号なし 32 ビット整数。
		/// </summary>
		UInt32 = 0,

		/// <summary>
		/// UTF-16LE 文字列。
		/// </summary>
		String = 1,

		/// <summary>
		/// バイト配列。
		/// </summary>
		Binary = 2,

		/// <summary>
		/// 真偽値 ( 32 ビット )。
		/// </summary>
		Bool = 3,

		/// <summary>
		/// 符号なし 64 ビット整数。
		/// </summary>
		UInt64 = 4,

		/// <summary>
		/// 符号なし 16 ビット整数。
		/// </summary>
		UInt16 = 5,

		/// <summary>
		/// GUID ( 128 ビット )。
		/// </summary>
		Guid = 6,
	}
}
