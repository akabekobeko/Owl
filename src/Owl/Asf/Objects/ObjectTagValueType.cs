
namespace Owl.Asf.Objects
{
	/// <summary>
	/// タグ値のデータ型を表します。
	/// 各値の実数は Extended Content Description Object のデータ型を表す値に対応しています。
	/// Windows Media Format の WMT_ATTR_DATATYPE とは一致しない点に注意してください。
	/// </summary>
	enum ObjectTagValueType
	{
		/// <summary>
		/// UTF-16LE 文字列。
		/// </summary>
		String = 0,

		/// <summary>
		/// バイト配列。
		/// </summary>
		Binary,

		/// <summary>
		/// 真偽値 ( 32 ビット )。
		/// </summary>
		Bool,

		/// <summary>
		/// 符号なし 32 ビット整数。
		/// </summary>
		UInt32,

		/// <summary>
		/// 符号なし 64 ビット整数。
		/// </summary>
		UInt64,

		/// <summary>
		/// 符号なし 16 ビット整数。
		/// </summary>
		UInt16
	}
}
