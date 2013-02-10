using System.IO;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// オブジェクトのタグ値を読み取ります。
	/// </summary>
	class ObjectTagValueReader
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="position">ストリームにおける値の位置。</param>
		/// <param name="length">ストリームにおける値の長さ ( バイト数 )。</param>
		public ObjectTagValueReader( long position, int length )
		{
			this.Position = position;
			this.Length   = length;
		}

		/// <summary>
		/// 値をバイト配列として読み取ります。
		/// </summary>
		/// <param name="src">値を読み取るストリーム。</param>
		/// <returns>値となるバイト配列。</returns>
		public byte[] Read( Stream src )
		{
			var position = src.Position;
			src.Seek( this.Position, SeekOrigin.Begin );

			var value = src.ReadBytes( this.Length );
			src.Seek( position, SeekOrigin.Begin );

			return value;
		}

		/// <summary>
		/// 値の長さを取得します。
		/// </summary>
		public int Length { get; private set; }

		/// <summary>
		/// 値の位置を取得します。
		/// </summary>
		public long Position { get; private set; }
	}
}
