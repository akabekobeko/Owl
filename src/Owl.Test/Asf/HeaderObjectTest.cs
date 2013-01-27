using System;
using System.IO;
using NUnit.Framework;
using Owl.Asf.Objects;
using Owl.Asf;

namespace Owl.Test.Asf
{
	/// <summary>
	/// HeaderObject をテストします。
	/// </summary>
	[TestFixture]
	public class HeaderObjectTest
	{
		/// <summary>
		/// テスト用のヘッダーを生成します。
		/// </summary>
		/// <param name="src">ヘッダーとなるストリーム</param>
		/// <param name="childObjectCount"></param>
		private Stream CreateTestHeader( IAsfObject[] childObjects )
		{
			var src = new MemoryStream();
			if( childObjects == null || childObjects.Length == 0 )
			{
				// ヘッダー情報 ( 24 byte ) + 子オブジェクト総数 ( 4 byte ) + 予約領域 ( 2 byte ) で少なくとも 30 byte 必要
				src.Write( HeaderObject.Id.ToByteArray(), 0, 16 );
				src.Write( BitConverter.GetBytes( ( long )30 ), 0, 8 );
				src.Write( BitConverter.GetBytes( 0 ), 0, 4 );
				src.Write( new byte[ 2 ], 0, 2 );
			}
			else
			{
				// 総サイズ
				long size = 30;
				foreach( IAsfObject obj in childObjects )
				{
					size += obj.Size;
				}

				// HeaderObject
				src.Write( HeaderObject.Id.ToByteArray(), 0, 16 );
				src.Write( BitConverter.GetBytes( size ), 0, 8 );
				src.Write( BitConverter.GetBytes( childObjects.Length ), 0, 4 );
				src.Write( new byte[ 2 ], 0, 2 );

				// 子オブジェクト
				foreach( IAsfObject obj in childObjects )
				{
					obj.Save( null, src );
				}
			}

			return src;
		}

		/// <summary>
		/// タグの所持チェックをテストします。
		/// </summary>
		[Test]
		public void HasValue()
		{
			// ASF ヘッダー
			using( var src = this.CreateTestHeader( new IAsfObject[] { new FilePropertiesObject( null ) } ) )
			{
				var headerObject = new HeaderObject( src );
				Assert.AreEqual( headerObject.HasValue( AsfTags.FileSize ), true );
				Assert.AreEqual( headerObject.HasValue( AsfTags.Title    ), false );
			}
		}

		/// <summary>
		/// ストリームが ASF 形式であることの判定をテストします。
		/// </summary>
		[Test]
		public void IsAsf()
		{
			// null 参照
			Assert.Throws< ArgumentNullException >( () =>
			{
				var headerObject = new HeaderObject( null );
			} );

			// ASF 形式ではない
			Assert.Throws< NotSupportedException >( () =>
			{
				using( var src = new MemoryStream() )
				{
					var headerObject = new HeaderObject( src );
				}
			} );

			// ASF ヘッダー
			using( var src = this.CreateTestHeader( null ) )
			{
				var headerObject = new HeaderObject( src );
				Assert.AreEqual( src.Length, headerObject.Size );
			}
		}
	}
}
