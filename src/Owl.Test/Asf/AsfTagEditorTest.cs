using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Owl.Asf;
using System.IO;

namespace Owl.Test.Asf
{
	/// <summary>
	/// AsfTagEditor のテストを実行します。
	/// </summary>
	[TestFixture]
	public class AsfTagEditorTest
	{
		/// <summary>
		/// データの読み込みをテストします。
		/// </summary>
		public void Read()
		{
			var path = String.Format( @"{0}\TestData\test.wma", AppDomain.CurrentDomain.BaseDirectory );
			using( var editor = new AsfTagEditor( new FileStream( path, FileMode.Open, FileAccess.ReadWrite ) ) )
			{
				Assert.AreEqual( "Title",           editor.Read( Tags.Title          ) as string );
				Assert.AreEqual( "Artist",          editor.Read( Tags.Artist         ) as string );
				Assert.AreEqual( "Album",           editor.Read( Tags.AlbumTitle     ) as string );
				Assert.AreEqual( "1",               editor.Read( Tags.TrackNumber    ) as string );
				Assert.AreEqual( "2011",            editor.Read( Tags.ReleaseDate    ) as string );
				Assert.AreEqual( "Genre",           editor.Read( Tags.Genre          ) as string );
				Assert.AreEqual( "Comment",         editor.Read( Tags.Comment        ) as string );
				Assert.AreEqual( "Copyright",       editor.Read( Tags.Copyright      ) as string );
				Assert.AreEqual( "Lebel",           editor.Read( Tags.Publisher      ) as string );
				Assert.AreEqual( "Album Artist",    editor.Read( Tags.AlbumArtist    ) as string );
				Assert.AreEqual( "Composer",        editor.Read( Tags.Composer       ) as string );
				Assert.AreEqual( "Original Artist", editor.Read( Tags.OriginalArtist ) as string );
				Assert.AreEqual( 10330000,         editor.Read( Tags.Duration       ) as ulong? );
			}
		}

		/// <summary>
		/// データの保存をテストします。
		/// </summary>
		[Test]
		public void Save()
		{
			var path = String.Format( @"{0}\TestData\test.wma", AppDomain.CurrentDomain.BaseDirectory );
			using( var editor = new AsfTagEditor( new FileStream( path, FileMode.Open, FileAccess.ReadWrite ) ) )
			{
				var dest = new MemoryStream();
				editor.Save( dest );

				var size = editor.Read( Tags.FileSize ) as long?;
				Assert.AreEqual( size, dest.Length, "保存後のファイル サイズ" );
			}
		}
	}
}
