using System;
using System.IO;
using NUnit.Framework;
using Owl.Asf.Objects;

namespace Owl.Test.Asf
{
	/// <summary>
	/// HeaderObject をテストします。
	/// </summary>
	[TestFixture]
	public class HeaderObjectTest
	{
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
			using( var src = new MemoryStream() )
			{
				// ヘッダー情報 ( 24 byte ) + 子オブジェクト総数 ( 4 byte ) + 予約領域 ( 2 byte ) で少なくとも 30 byte 必要
				src.Write( HeaderObject.Id.ToByteArray(), 0, 16 );
				src.Write( BitConverter.GetBytes( ( long )30 ), 0, 8 );
				src.Write( BitConverter.GetBytes( 0 ), 0, 4 );
				src.Write( new byte[ 2 ], 0, 2 );

				var headerObject = new HeaderObject( src );
				Assert.AreEqual( src.Length, headerObject.Size );
			}
		}
	}
}
