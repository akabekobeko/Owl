using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Owl.Asf;
using Owl.Asf.Objects;

namespace Owl.Test.Asf
{
	/// <summary>
	/// ExtendedContentDescriptionObjectTest をテストします。
	/// </summary>
	[TestFixture]
	public class ExtendedContentDescriptionObjectTest
	{
		/// <summary>
		/// 編集と保存をテストします。
		/// </summary>
		[Test]
		public void Edit()
		{
			var src = new MemoryStream();
			{
				var obj = new ExtendedContentDescriptionObject( null, 0 );
				foreach( var data in TestData )
				{
					obj.Write( data.Key, data.Value );
				}

				obj.Save( null, src );
				src.Seek( 0, SeekOrigin.Begin );
			}

			var header = new ObjectHeader( src );
			var obj2 = new ExtendedContentDescriptionObject( src, header.Size );

			Assert.AreEqual( src.Length, obj2.Size, "サイズ" );
			foreach( var data in TestData )
			{
				var value = obj2.Read( src, data.Key );
				Assert.AreEqual( data.Value, value, "タグ情報" );
			}
		}

		/// <summary>
		/// テスト用データ。
		/// </summary>
		public static readonly Dictionary< AsfTagInfo, string > TestData = new Dictionary< AsfTagInfo, string >()
		{
			{ AsfTags.TrackNumber, "12"                    },
			{ AsfTags.AlbumTitle,  "アルバム"              },
			{ AsfTags.AlbumArtist, "アルバム アーティスト" },
			{ AsfTags.Composer,    "作曲者"                },
			{ AsfTags.Writer,      "作詞者"                },
		};
	}
}
