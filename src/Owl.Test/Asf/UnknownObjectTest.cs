using System;
using System.IO;
using NUnit.Framework;
using Owl.Asf.Objects;

namespace Owl.Test.Asf
{
	/// <summary>
	/// UnknownObject をテストします。
	/// </summary>
	[TestFixture]
	public class UnknownObjectTest
	{
		/// <summary>
		/// インスタンス生成をテストします。
		/// </summary>
		[Test]
		public void Create()
		{
			// 正常系
			var src    = new MemoryStream();
			var header = new ObjectHeader( Guid.NewGuid(), ObjectHeader.ClassByteSize );
			{
				var test = new UnknownObject( src, header );
				Assert.AreEqual( header.Guid, test.Id   );
				Assert.AreEqual( header.Size, test.Size );
			}

			// 異常系
			Assert.Throws< ArgumentNullException >( () => { var obj = new UnknownObject( null, null   ); } );
			Assert.Throws< ArgumentNullException >( () => { var obj = new UnknownObject( src,  null   ); } );
			Assert.Throws< ArgumentNullException >( () => { var obj = new UnknownObject( null, header ); } );		
		}
	}
}
