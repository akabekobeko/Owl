using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

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
	}
}
