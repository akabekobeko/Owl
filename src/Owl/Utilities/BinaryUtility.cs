using System;
using System.Text;

namespace Owl.Utilities
{
	/// <summary>
	/// バイナリ操作に関するユーティリティです。
	/// </summary>
	static class BinaryUtility
	{
		/// <summary>
		/// バイト配列を UTF-16LE として文字列に変換します。
		/// </summary>
		/// <param name="bytes">バイト配列。</param>
		/// <returns>変換した文字列。</returns>
		public static string BytesUtf16StringToString( byte[] bytes )
		{
			// 文字列化と終端の NULL 文字を除去
			var str = Encoding.Unicode.GetString( bytes, 0, bytes.Length );
			if( str[ str.Length - 1 ] == '\0' )
			{
				if( str.Length == 1 ) { return String.Empty; }

				var sb = new StringBuilder( str );
				sb.Remove( sb.Length - 1, 1 );
				str = sb.ToString();
			}

			return str;
		}

		/// <summary>
		/// 文字列を NULL 終端の UTF-16LE 文字列バイト配列に変換します。
		/// </summary>
		/// <param name="text">文字列</param>
		/// <returns></returns>
		public static byte[] StringToBytesUtf16String( string text )
		{
			var sb = new StringBuilder( text );
			sb.Append( '\0' );
			return Encoding.Unicode.GetBytes( sb.ToString() );
		}
	}
}
