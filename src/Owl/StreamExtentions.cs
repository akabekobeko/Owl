using System;
using System.IO;

namespace Owl
{
	/// <summary>
	/// Stream の拡張クラスです。
	/// </summary>
	static class StreamExtentions
	{
		/// <summary>
		/// 真偽値 ( 8 ビット ) を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static bool ReadBool( this Stream stream )
		{
			return BitConverter.ToBoolean( stream.ReadBytes( 1 ), 0 );
		}

		/// <summary>
		/// バイト配列を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <param name="count">読み取るバイト数。</param>
		/// <returns>読み取った値。</returns>
		public static byte[] ReadBytes( this Stream stream, int count )
		{
			var b = new byte[ count ];
			stream.Read( b, 0, count );
			return b;
		}

		/// <summary>
		/// GUID ( 128 ビット ) を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static Guid ReadGuid( this Stream stream )
		{
			return new Guid( stream.ReadBytes( 16 ) );
		}

		/// <summary>
		/// 符号付き 16 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="reader">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static short ReadInt16( this Stream reader )
		{
			return BitConverter.ToInt16( reader.ReadBytes( 2 ), 0 );
		}

		/// <summary>
		/// 符号付き 32 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static int ReadInt32( this Stream stream )
		{
			return BitConverter.ToInt32( stream.ReadBytes( 4 ), 0 );
		}

		/// <summary>
		/// 符号付き 64 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static long ReadInt64( this Stream stream )
		{
			return BitConverter.ToInt64( stream.ReadBytes( 8 ), 0 );
		}

		/// <summary>
		/// 符号なし 16 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static ushort ReadUInt16( this Stream stream )
		{
			return BitConverter.ToUInt16( stream.ReadBytes( 2 ), 0 );
		}

		/// <summary>
		/// 符号なし 32 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static uint ReadUInt32( this Stream stream )
		{
			return BitConverter.ToUInt32( stream.ReadBytes( 4 ), 0 );
		}

		/// <summary>
		/// 符号なし 64 ビット整数値を読み取り、ストリームの位置を進めます。
		/// </summary>
		/// <param name="stream">ストリーム。</param>
		/// <returns>読み取った値。</returns>
		public static ulong ReadUInt64( this Stream stream )
		{
			return BitConverter.ToUInt64( stream.ReadBytes( 8 ), 0 );
		}
	}
}
