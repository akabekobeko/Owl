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
		/// テスト用のデータ ストリームを生成します
		/// </summary>
		/// <returns>ストリーム。</returns>
		private Stream CreateStream()
		{
			var guid = Guid.NewGuid();
			var value = new byte[ 1024 ];
			var src = new MemoryStream();

			var b = guid.ToByteArray();
			src.Write( b, 0, b.Length );

			b = BitConverter.GetBytes( ( ulong )( ObjectHeader.ClassByteSize + value.Length ) );
			src.Write( b, 0, b.Length );
			src.Write( value, 0, value.Length );
			src.Seek( 0, SeekOrigin.Begin );

			return src;
		}

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

		/// <summary>
		/// 保存をテストします。
		/// </summary>
		[Test]
		public void Save()
		{
			var src       = this.CreateStream();
			var srcObject = new UnknownObject( src, new ObjectHeader( src ) );

			// 書き込み後、ストリーム上の位置が終端となるため、ヘッダ読み込み用に先頭へ戻す
			// Owl クライアントは ASF オブジェクトを直接操作しないため、通常は意識する必要のない処理
			//
			var dest = new MemoryStream();
			srcObject.Save( src, dest );
			dest.Seek( 0, SeekOrigin.Begin );

			var destObject = new UnknownObject( dest, new ObjectHeader( dest ) );

			// 複製が適切におこなわれたことをチェック
			Assert.AreEqual( srcObject.Size, destObject.Size, "Size" );
			Assert.AreEqual( srcObject.Id,   destObject.Id,   "ID"   );
		}
	}
}
