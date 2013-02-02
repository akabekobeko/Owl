using System;
using System.IO;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// File Properties Object を表します。
	/// このオブジェクトの所有するデータは全て固定長・固定型でああるため、Write メソッドによる編集はサポートしません。
	/// 編集をサポートするデータは FileSize のみとなりますが、プロパティ経由で操作してください。
	/// </summary>
	class FilePropertiesObject : IAsfObject
	{
		/// <summary>
		/// インスタンスを初期化します。
		/// </summary>
		/// <param name="src">オブジェクト情報を読み取るストリーム。位置はオブジェクトのボディ先頭 ( サイズ情報の直後 ) に設定します。新規作成なら null を指定します。</param>
		public FilePropertiesObject( Stream src )
		{
			if( src == null )
			{
				this.FileId   = Guid.NewGuid();
				this.FileSize = ( ulong )this.Size;
			}
			else
			{
				this.FileId           = src.ReadGuid();
				this.FileSize         = src.ReadUInt64();
				this.CreationDate     = DateTime.FromFileTimeUtc( ( long )src.ReadUInt64() );
				this.DataPacketsCount = src.ReadUInt64();
				this.Duration         = src.ReadUInt64();
				this.SendDuration     = TimeSpan.FromTicks( ( long )src.ReadUInt64() );
				this.Preroll          = src.ReadUInt64();

				// 再生時間から Preroll x 10000 を差し引いたものが、実際の演奏時間となる。
				// この値は複数値からの算出が必要なので、遅延読み込みせずにキャッシュする。
				//
				this.Duration -= ( this.Preroll * FilePropertiesObject.PrerollDelta );

				this.Flags                 = src.ReadUInt32();
				this.MinimumDataPacketSize = src.ReadUInt32();
				this.MaximumDataPacketSize = src.ReadUInt32();
				this.MaximumBitrate        = src.ReadUInt32();
			}
		}

		/// <summary>
		/// 指定されたタグ情報を所有していることを調べます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <returns>所有している場合は true。それ以外は false。</returns>
		public bool HasValue( AsfTagInfo tag )
		{
			return ( tag == AsfTags.Duration || tag == AsfTags.FileSize );
		}

		/// <summary>
		/// タグ情報を読み取ります。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="src">情報を読み取るストリーム。</param>
		/// <returns>成功時はタグ情報。それ以外は null 参照。</returns>
		public object Read( AsfTagInfo tag )
		{
			if( tag == AsfTags.Duration )
			{
				return this.Duration;
			}
			else if( tag == AsfTags.FileSize )
			{
				return this.FileSize;
			}

			return null;
		}

		/// <summary>
		/// 編集内容を保存します。
		/// </summary>
		/// <param name="src">タグ情報の読み出し元となるストリーム。</param>
		/// <param name="dest">保存先となるストリーム。</param>
		public void Save( Stream dest )
		{
			// ヘッダ
			dest.Write( FilePropertiesObject.Id.ToByteArray(), 0, 16 );
			dest.Write( BitConverter.GetBytes( ( ulong )this.Size ), 0, 8 );

			dest.Write( this.FileId.ToByteArray(), 0, 16 );
			dest.Write( BitConverter.GetBytes( this.FileSize ), 0, 8 );
			dest.Write( BitConverter.GetBytes( ( ulong )this.CreationDate.Ticks ), 0, 8 );
			dest.Write( BitConverter.GetBytes( this.DataPacketsCount ), 0, 8 );

			// 実際の演奏時間から再生時間に変換
			{
				var d = this.Duration + ( this.Preroll * FilePropertiesObject.PrerollDelta );
				dest.Write( BitConverter.GetBytes( d ), 0, 8 );
			}

			dest.Write( BitConverter.GetBytes( ( ulong )this.SendDuration.Ticks ), 0, 8 );
			dest.Write( BitConverter.GetBytes( this.Preroll                     ), 0, 8 );
			dest.Write( BitConverter.GetBytes( this.Flags                       ), 0, 4 );
			dest.Write( BitConverter.GetBytes( this.MinimumDataPacketSize       ), 0, 4 );
			dest.Write( BitConverter.GetBytes( this.MaximumDataPacketSize       ), 0, 4 );
			dest.Write( BitConverter.GetBytes( this.MaximumBitrate              ), 0, 4 );
		}

		/// <summary>
		/// タグ情報を書き込みます。
		/// 既存のタグがなければ追加、ある場合は更新をおこないます。
		/// </summary>
		/// <param name="tag">タグ。</param>
		/// <param name="value">タグ情報。値を削除する場合は null を指定します。</param>
		public void Write( AsfTagInfo tag, object value )
		{
			throw new NotSupportedException( "This object is read-only." );
		}

		/// <summary>
		/// ファイルの作成日を取得または設定します。
		/// </summary>
		public DateTime CreationDate { get; private set; }

		/// <summary>
		/// Data Object 内に存在するパケットエントリの総数を取得または設定します。
		/// </summary>
		public ulong DataPacketsCount { get; private set; }

		/// <summary>
		/// 演奏時間を取得または設定します。
		/// </summary>
		public ulong Duration { get; private set; }

		/// <summary>
		/// ファイルの識別子を取得または設定します。
		/// </summary>
		public Guid FileId { get; private set; }

		/// <summary>
		/// ファイル サイズを取得または設定します。
		/// </summary>
		public ulong FileSize { get; set; }

		/// <summary>
		/// フラグを取得または設定します。
		/// </summary>
		public uint Flags { get; private set; }

		/// <summary>
		/// 送信時における最小のデータパケットのサイズを取得または設定します。
		/// </summary>
		public uint MinimumDataPacketSize { get; private set; }

		/// <summary>
		/// 送信時における最大のデータパケットのサイズを取得または設定します。
		/// </summary>
		public uint MaximumDataPacketSize { get; private set; }

		/// <summary>
		/// 送信時における最大ビットレートを取得または設定します。
		/// </summary>
		public uint MaximumBitrate { get; private set; }

		/// <summary>
		/// ファイル再生を始める前に必要なバッファリング時間を取得または設定します。
		/// </summary>
		public ulong Preroll { get; private set; }

		/// <summary>
		/// 送信時間を取得または設定します。
		/// </summary>
		public TimeSpan SendDuration { get; private set; }

		/// <summary>
		/// オブジェクトのサイズを取得します。
		/// File Properties Object は固定長のデータのみで構成されるため、サイズは固定です。
		/// </summary>
		public long Size { get { return 104; } }

		/// <summary>
		/// オブジェクトの識別子です。
		/// </summary>
		public static readonly Guid Id = new Guid( "8CABDCA1-A947-11CF-8EE4-00C00C205365" );

		/// <summary>
		/// ファイル再生を始める前に必要なバッファリング時間を、演奏時間の単位にあわせるための時間値。
		/// </summary>
		private static readonly ulong PrerollDelta = 10000;
	}
}
