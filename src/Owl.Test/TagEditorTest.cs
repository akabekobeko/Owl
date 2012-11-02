using System;
using System.IO;
using NUnit.Framework;

namespace Owl.Test
{
	/// <summary>
	/// TagEditor をテストします。
	/// </summary>
	[TestFixture]
	public class TagEditorTest
	{
		/// <summary>
		/// SrcIsNullOrEmpty のテストケース。
		/// </summary>
		private static MemoryStream[] SrcIsNullOrEmptyCases = { null, new MemoryStream() };

		/// <summary>
		/// null または空のストリームを指定したインスタンス生成を試します。
		/// </summary>
		[Test, TestCaseSource( "SrcIsNullOrEmptyCases" ), ExpectedException( typeof( ArgumentException ) )]
		public void SrcIsNullOrEmpty( Stream src )
		{
			var editor = new TagEditor( src );
		}
	}
}
