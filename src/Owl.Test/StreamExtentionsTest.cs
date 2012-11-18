using System;
using System.IO;
using NUnit.Framework;

namespace Owl.Test
{
	/// <summary>
	/// StreamExtentions をテストします。
	/// </summary>
	[TestFixture]
	public class StreamExtentionsTest
	{
		/// <summary>
		/// 真偽値の読み込みをテストします。
		/// </summary>
		/// <param name="testValue">検証する真偽値。</param>
		[TestCase( true,  TestName = "true"  )]
		[TestCase( false, TestName = "false" )]
		public void ReadBool( bool testValue )
		{
			using( var stream = new MemoryStream() )
			{
				var bytes = BitConverter.GetBytes( testValue );
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadBool();
				Assert.AreEqual( value, testValue );
			}
		}

		/// <summary>
		/// GUID の読み込みをテストします。
		/// </summary>
		[Test]
		public void ReadGuid()
		{
			var testValue = new Guid( "75B22633-668E-11CF-A6D9-00AA0062CE6C" );
			using( var stream = new MemoryStream() )
			{
				var bytes = testValue.ToByteArray();
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadGuid();
				Assert.AreEqual( value, testValue );
			}
		}

		/// <summary>
		/// 符号付き 16 ビット整数値の読み込みをテストします。
		/// </summary>
		[Test]
		public void ReadInt16()
		{
			Int16 testValue = 1024;
			using( var stream = new MemoryStream() )
			{
				var bytes = BitConverter.GetBytes( testValue );
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadInt16();
				Assert.AreEqual( value, testValue );
			}
		}
	
		/// <summary>
		/// 符号付き 32 ビット整数値の読み込みをテストします。
		/// </summary>
		[Test]
		public void ReadInt32()
		{
			Int32 testValue = 2048;
			using( var stream = new MemoryStream() )
			{
				var bytes = BitConverter.GetBytes( testValue );
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadInt32();
				Assert.AreEqual( value, testValue );
			}
		}

		/// <summary>
		/// 符号付き 64 ビット整数値の読み込みをテストします。
		/// </summary>
		[Test]
		public void ReadInt64()
		{
			Int64 testValue = 4096;
			using( var stream = new MemoryStream() )
			{
				var bytes = BitConverter.GetBytes( testValue );
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadInt64();
				Assert.AreEqual( value, testValue );
			}
		}

		/// <summary>
		/// 符号なし 16 ビット整数値の読み込みをテストします。
		/// </summary>
		[Test]
		public void ReadUInt16()
		{
			UInt16 testValue = 1024;
			using( var stream = new MemoryStream() )
			{
				var bytes = BitConverter.GetBytes( testValue );
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadUInt16();
				Assert.AreEqual( value, testValue );
			}
		}

		/// <summary>
		/// 符号なし 32 ビット整数値の読み込みをテストします。
		/// </summary>
		[Test]
		public void ReadUInt32()
		{
			UInt32 testValue = 2048;
			using( var stream = new MemoryStream() )
			{
				var bytes = BitConverter.GetBytes( testValue );
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadUInt32();
				Assert.AreEqual( value, testValue );
			}
		}

		/// <summary>
		/// 符号なし 64 ビット整数値の読み込みをテストします。
		/// </summary>
		[Test]
		public void ReadUInt64()
		{
			UInt64 testValue = 4096;
			using( var stream = new MemoryStream() )
			{
				var bytes = BitConverter.GetBytes( testValue );
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadUInt64();
				Assert.AreEqual( value, testValue );
			}
		}
	}
}
