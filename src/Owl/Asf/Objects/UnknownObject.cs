using System;
using System.IO;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// 未知のオブジェクトを表します。
	/// </summary>
	internal sealed class UnknownObject : IAsfObject
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="src">
		/// オブジェクト情報を読み取るストリーム。位置はサイズ情報の直後に設定します。
		/// このクラスは未知のオブジェクトを表すため、新規作成はおこなえません。
		/// よって、この引数に null を指定した場合は例外となります。
		/// </param>
		/// <param name="header">ヘッダ情報。</param>
		/// <exception cref="ArgumentNullException">src が null 参照です。</exception>
		public UnknownObject( Stream src, ObjectHeader header )
		{
			if( src == null || header == null ) { throw new ArgumentNullException( "'src' or 'header' is null." ); }

			this.Id        = header.Guid;
			this.Size      = header.Size;
			this._position = src.Position;
			this._src      = src;
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		/// <exception cref="NotSupportedException">未サポートの操作です。</exception>
		public bool HasValue( AsfTagInfo tag )
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		/// <exception cref="NotSupportedException">未サポートの操作です。</exception>
		public object Read( AsfTagInfo tag )
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// 編集内容を保存します
		/// </summary>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( Stream dest )
		{
			// ヘッダ
			{
				var guid = this.Id.ToByteArray();
				dest.Write( guid, 0, guid.Length );

				var objectSize = BitConverter.GetBytes( ( ulong )this.Size );
				dest.Write( objectSize, 0, objectSize.Length );
			}

			var position = this._src.Position;
			this._src.Seek( this._position, SeekOrigin.Begin );

			// ボディ
			var size = ( int )this.Size - ObjectHeader.ClassByteSize;
			var buffer = new byte[ UnknownObject.BufferSize ];
			do
			{
				var read = this._src.Read( buffer, 0, ( size > UnknownObject.BufferSize ? UnknownObject.BufferSize : size ) );
				dest.Write( buffer, 0, read );
				size -= read;

			} while( size > 0 );
		}

		/// <summary>
		/// タグ情報を追加、更新、または削除します。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		/// <exception cref="NotSupportedException">未サポートの操作です。</exception>
		public void Write( AsfTagInfo tag, object value )
		{
			throw new NotSupportedException();
		}

		/// <summary>
		/// オブジェクトの識別子を取得します。
		/// </summary>
		public Guid Id { get; private set; }

		/// <summary>
		/// オブジェクトのサイズを取得します。
		/// </summary>
		public long Size { get; private set; }

		/// <summary>
		/// ASF タグ情報の読み取り元ストリーム。
		/// </summary>
		private Stream _src;

		/// <summary>
		/// ストリーム上においてオブジェクトの内容が開始される位置。
		/// </summary>
		private long _position;

		/// <summary>
		/// データ保存時のバッファ サイズ。
		/// </summary>
		private static readonly int BufferSize = 1024;
	}
}
