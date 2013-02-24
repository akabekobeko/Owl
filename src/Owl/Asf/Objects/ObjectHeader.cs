using System;
using System.IO;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// Object ヘッダ部分を表します。
	/// ヘッダは Object の識別子となる GUID と、ヘッダも含む Object 全体のデータ サイズで構成されます。
	/// </summary>
	sealed class ObjectHeader
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="src">ヘッダの開始位置を指しているデータ ストリーム。</param>
		public ObjectHeader( Stream src )
		{
			this.Guid = src.ReadGuid();
			this.Size = src.ReadInt64();
		}

		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="guid">GUID。</param>
		/// <param name="size">サイズ。</param>
		public ObjectHeader( Guid guid, long size )
		{
			this.Guid = guid;
			this.Size = size;
		}

		/// <summary>
		/// ヘッダ情報のサイズ ( バイト単位 ) を取得します。
		/// </summary>
		public static readonly int ClassByteSize = 24;

		/// <summary>
		/// GUID を取得します。
		/// </summary>
		public Guid Guid { get; private set; }

		/// <summary>
		/// サイズを取得します。
		/// </summary>
		public long Size { get; private set; }
	}
}
