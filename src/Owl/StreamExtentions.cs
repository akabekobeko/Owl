using System;
using System.IO;

namespace Owl
{
	/// <summary>
	/// Stream の拡張クラスです。
	/// </summary>
	internal static class StreamExtentions
	{
		/// <summary>
		/// 真偽値 ( 8 ビット ) を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static bool ReadBool( this Stream reader )
		{
			return reader.ReadBool( 1 );
		}

		/// <summary>
		/// 真偽値を読み取り、ストリームの位置を進めます。
		/// このメソッドでは指定されたバイト数分、ストリームを読み進めますが、
		/// データとして取得される値は、読み取ったバイト配列の先頭部分から必要なデータサイズ分となります。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static bool ReadBool( this Stream reader, int count )
		{
			return BitConverter.ToBoolean( reader.ReadBytes( count ), 0 );
		}

		/// <summary>
		/// バイト配列を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static byte[] ReadBytes( this Stream reader, int count )
		{
			var b = new byte[ count ];
			reader.Read( b, 0, count );
			return b;
		}

		/// <summary>
		/// GUID ( 128 ビット ) を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static Guid ReadGuid( this Stream reader )
		{
			return reader.ReadGuid( 16 );
		}

		/// <summary>
		/// GUID を読み取り、ストリームの位置を進めます。
		/// このメソッドでは指定されたバイト数分、ストリームを読み進めますが、
		/// データとして取得される値は、読み取ったバイト配列の先頭部分から必要なデータサイズ分となります。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		/// <exception cref="ArgumentException">count に指定された数値が 16 バイトを下回っている</exception>
		public static Guid ReadGuid( this Stream reader, int count )
		{
			var b = reader.ReadBytes( count );
			if( count == 16 )
			{
				return new Guid( b );
			}
			else if( count > 16 )
			{
				// Guid のコンストラクタに指定するバイト配列は 16 ビットでなければならない
				var data = new byte[ 16 ];
				Array.Copy( b, 0, data, 0, 16 );
				return new Guid( data );
			}
			else
			{
				throw new ArgumentException( "count" );
			}
		}

		/// <summary>
		/// 符号付き 16 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static short ReadInt16( this Stream reader )
		{
			return reader.ReadInt16( 2 );
		}

		/// <summary>
		/// 符号付き 16 ビット整数値を読み取り、ストリームの位置を進めます。
		/// このメソッドでは指定されたバイト数分、ストリームを読み進めますが、
		/// データとして取得される値は、読み取ったバイト配列の先頭部分から必要なデータサイズ分となります。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static short ReadInt16( this Stream reader, int count )
		{
			return BitConverter.ToInt16( reader.ReadBytes( count ), 0 );
		}

		/// <summary>
		/// 符号付き 32 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static int ReadInt32( this Stream reader )
		{
			return reader.ReadInt32( 4 );
		}

		/// <summary>
		/// 符号付き 32 ビット整数値を読み取り、ストリームの位置を進めます。
		/// このメソッドでは指定されたバイト数分、ストリームを読み進めますが、
		/// データとして取得される値は、読み取ったバイト配列の先頭部分から必要なデータサイズ分となります。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static int ReadInt32( this Stream reader, int count )
		{
			return BitConverter.ToInt32( reader.ReadBytes( count ), 0 );
		}

		/// <summary>
		/// 符号付き 64 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static long ReadInt64( this Stream reader )
		{
			return reader.ReadInt64( 8 );
		}

		/// <summary>
		/// 符号付き 64 ビット整数値を読み取り、ストリームの位置を進めます。
		/// このメソッドでは指定されたバイト数分、ストリームを読み進めますが、
		/// データとして取得される値は、読み取ったバイト配列の先頭部分から必要なデータサイズ分となります。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static long ReadInt64( this Stream reader, int count )
		{
			return BitConverter.ToInt64( reader.ReadBytes( count ), 0 );
		}

		/// <summary>
		/// 符号なし 16 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static ushort ReadUInt16( this Stream stream )
		{
			return stream.ReadUInt16( 2 );
		}

		/// <summary>
		/// 符号なし 16 ビット整数値を読み取り、ストリームの位置を進めます。
		/// このメソッドでは指定されたバイト数分、ストリームを読み進めますが、
		/// データとして取得される値は、読み取ったバイト配列の先頭部分から必要なデータサイズ分となります。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static ushort ReadUInt16( this Stream reader, int count )
		{
			return BitConverter.ToUInt16( reader.ReadBytes( count ), 0 );
		}

		/// <summary>
		/// 符号なし 32 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static uint ReadUInt32( this Stream reader )
		{
			return reader.ReadUInt32( 4 );
		}

		/// <summary>
		/// 符号なし 32 ビット整数値を読み取り、ストリームの位置を進めます。
		/// このメソッドでは指定されたバイト数分、ストリームを読み進めますが、
		/// データとして取得される値は、読み取ったバイト配列の先頭部分から必要なデータサイズ分となります。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static uint ReadUInt32( this Stream reader, int count )
		{
			return BitConverter.ToUInt32( reader.ReadBytes( count ), 0 );
		}

		/// <summary>
		/// 符号なし 64 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static ulong ReadUInt64( this Stream reader )
		{
			return reader.ReadUInt64( 8 );
		}

		/// <summary>
		/// 符号なし 64 ビット整数値を読み取り、ストリームの位置を進めます。
		/// このメソッドでは指定されたバイト数分、ストリームを読み進めますが、
		/// データとして取得される値は、読み取ったバイト配列の先頭部分から必要なデータサイズ分となります。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static ulong ReadUInt64( this Stream reader, int count )
		{
			return BitConverter.ToUInt64( reader.ReadBytes( count ), 0 );
		}
	}
}
