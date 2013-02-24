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
				long                 size           = 30;
				FilePropertiesObject fileProperties = null;
				foreach( IAsfObject obj in childObjects )
				{
					size += obj.Size;
					if( obj is FilePropertiesObject )
					{
						fileProperties = obj as FilePropertiesObject;
					}
				}

				// FilePropertiesObject のサイズは全体サイズとなる
				if( fileProperties != null )
				{
					fileProperties.FileSize = ( ulong )size;
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
				
				// null 参照
				Assert.Throws< ArgumentNullException >( () =>
				{
					headerObject.HasValue( null );
				} );

				// 所持、未所持チェック
				Assert.AreEqual( true,  headerObject.HasValue( AsfTags.FileSize ) );
				Assert.AreEqual( false, headerObject.HasValue( AsfTags.Title    ) );
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

		/// <summary>
		/// 値の読み込みをテストします。
		/// </summary>
		[Test]
		public void Read()
		{
			// ASF ヘッダー
			using( var src = this.CreateTestHeader( new IAsfObject[] { new FilePropertiesObject( null ) } ) )
			{
				var headerObject = new HeaderObject( src );

				// null 参照
				Assert.Throws< ArgumentNullException >( () =>
				{
					headerObject.Read( null );
				} );

				// 読み込みテスト
				// HeaderObject しか書き込んでいないので、ファイルサイズはヘッダーのサイズと等しいはず
				// Title は書き込んでいないので null になるはず
				//
				Assert.AreEqual( headerObject.Size, headerObject.Read( AsfTags.FileSize ) );
				Assert.AreEqual( null,              headerObject.Read( AsfTags.Title    ) );
			}
		}
	}
}
