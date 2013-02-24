using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using Owl.Asf;
using Owl.Asf.Objects;

namespace Owl.Test.Asf
{
	/// <summary>
	/// ContentDescriptionObject をテストします。
	/// </summary>
	[TestFixture]
	public class ContentDescriptionObjectTest
	{
		/// <summary>
		/// テスト用の ContentDescriptionObject を生成します。
		/// </summary>
		/// <returns>オブジェクト。</returns>
		private static ContentDescriptionObject CreateTestObject()
		{
			var obj = new ContentDescriptionObject( null, 0 );
			foreach( var testValue in TestData )
			{
				obj.Write( testValue.Key, testValue.Value );
			}

			return obj;
		}

		/// <summary>
		/// 編集と保存をテストします。
		/// </summary>
		[Test]
		public void Edit()
		{
			var dest = new MemoryStream();
			long size = 0;
			{
				var src1 = new MemoryStream();
				var obj  = new ContentDescriptionObject( null, 0 );
				foreach( var data in TestData )
				{
					obj.Write( data.Key, data.Value );
				}

				obj.Save( src1, dest );
				dest.Seek( 0, SeekOrigin.Begin );
				size = obj.Size;
			}

			var header = new ObjectHeader( dest );
			var obj2   = new ContentDescriptionObject( dest, header.Size );

			Assert.AreEqual( size, dest.Length, "サイズ" );
			foreach( var data in TestData )
			{
				var value = obj2.Read( dest, data.Key );
				Assert.AreEqual( data.Value, value, "タグ情報" );
			}
		}

		/// <summary>
		/// データ読み込みをテストします。
		/// </summary>
		[Test]
		public void Read()
		{
			var obj = CreateTestObject();
			foreach( var testValue in TestData )
			{
				var value = obj.Read( null, testValue.Key );
				Assert.AreEqual( testValue.Value, value, "タグ情報" );
			}
		}

		/// <summary>
		/// テスト用データを取得します。
		/// </summary>
		private static Dictionary< AsfTagInfo, string > TestData = new Dictionary< AsfTagInfo, string >()
		{
			{ AsfTags.Title,       "タイトル"         },
			{ AsfTags.Author,      "アーティスト"     },
			{ AsfTags.Copyright,   "著作権"           },
			{ AsfTags.Description, "詳細情報"         },
			{ AsfTags.Rating,      "保護者による制限" },
		};
	}
}
