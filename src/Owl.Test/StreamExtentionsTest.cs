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
		/// <param name="flag">検証する真偽値。</param>
		[TestCase( true,  TestName = "true"  )]
		[TestCase( false, TestName = "false" )]
		public void ReadBool( bool flag )
		{
			using( var stream = new MemoryStream() )
			{
				var bytes = BitConverter.GetBytes( flag );
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadBool();
				Assert.AreEqual( value, flag );
			}
		}

		/// <summary>
		/// GUID の読み込みをテストします。
		/// </summary>
		[Test]
		public void ReadGuid()
		{
			var guid = new Guid( "75B22633-668E-11CF-A6D9-00AA0062CE6C" );
			using( var stream = new MemoryStream() )
			{
				var bytes = guid.ToByteArray();
				stream.Write( bytes, 0, bytes.Length );
				stream.Seek( 0, SeekOrigin.Begin );

				var value = stream.ReadGuid();
				Assert.AreEqual( value, guid );
			}
		}
	}
}
