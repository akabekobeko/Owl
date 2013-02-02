using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// オブジェクト内のタグ値を表します。
	/// 
	/// </summary>
	class ObjectTagValue
	{
		/// <summary>
		/// ストリーム上のタグ値を遅延読み込みするための情報から、インスタンスを初期化します。
		/// 
		/// タグ値は可変長、かつ画像のように大きなサイズのデータもあるため、メモリ上への読み込みは、なるべく遅延されることが望まれます。
		/// インスタンス生成時はタグ値の位置とサイズ情報のみを記録し、値が必要となった時に改めて読み込みを実行します。
		/// </summary>
		/// <param name="type"></param>
		/// <param name="position"></param>
		/// <param name="length"></param>
		public ObjectTagValue( ObjectTagValueType type, long position, int length )
		{
			this.Type      = type;
			this._position = position;
			this._length   = length;
		}

		/// <summary>
		/// 
		/// </summary>
		public ObjectTagValueType Type { get; private set; }

		/// <summary>
		/// 値のストリーム上における開始位置。
		/// </summary>
		private long _position;

		/// <summary>
		/// 値の長さ ( バイト数 )。
		/// </summary>
		private int _length;
	}

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
