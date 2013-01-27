using System.IO;
using NUnit.Framework;
using Owl.Asf.Objects;

namespace Owl.Test.Asf
{
	/// <summary>
	/// FilePropertiesObject をテストします。
	/// </summary>
	[TestFixture]
	public class FilePropertiesObjectTest
	{
		/// <summary>
		/// ファイルサイズの更新をテストします。
		/// </summary>
		[Test]
		public void FileSize()
		{
			using( var stream = new MemoryStream() )
			{
				// ファイルサイズを更新
				var obj = new FilePropertiesObject( null );
				obj.FileSize = 2048;				
				obj.Save( stream );

				// オブジェクトのボディ部分から読み込み
				stream.Seek( ObjectHeader.ClassByteSize, SeekOrigin.Begin );
				obj = new FilePropertiesObject( stream );
				Assert.AreEqual( obj.FileSize, 2048, "Saved file size." ); 
			}
		}
	}
}
