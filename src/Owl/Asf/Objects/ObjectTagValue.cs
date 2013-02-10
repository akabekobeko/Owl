using System;
using System.IO;
using Owl.Utilities;

namespace Owl.Asf.Objects
{
	/// <summary>
	/// オブジェクト内のタグ値を表します。
	/// </summary>
	class ObjectTagValue
	{
		/// <summary>
		/// ストリーム上のタグ値を遅延読み込みするための情報から、インスタンスを初期化します。
		/// 
		/// タグ値は可変長、かつ画像のように大きなサイズのデータもあるため、メモリ上への読み込みは、なるべく遅延されることが望まれます。
		/// インスタンス生成時はタグ値の位置とサイズ情報のみを記録し、値が必要となった時に改めて読み込みを実行します。
		/// </summary>
		/// <param name="type">値の型。</param>
		/// <param name="position">ストリームにおける値の位置。</param>
		/// <param name="length">ストリームにおける値の長さ ( バイト数 )。</param>
		public ObjectTagValue( ObjectTagValueType type, long position, int length )
		{
			this.Type    = type;
			this._reader = new ObjectTagValueReader( position, length );
		}

		/// <summary>
		/// 値を新規作成するための情報から、インスタンスを初期化します。
		/// </summary>
		/// <param name="type">値の型。</param>
		/// <param name="value">値のバイト配列。</param>
		public ObjectTagValue( AsfTagDataType type, object value )
		{
			if( type == AsfTagDataType.Binary && value is byte[] )
			{
				this._value = ( byte[] )value;
				this.Type   = ObjectTagValueType.Binary;
			}
			else if( type == AsfTagDataType.Bool && value is bool )
			{
				// WMT_TYPE_BOOL は 4 バイトなので uint として扱う
				this._value = BitConverter.GetBytes( ( uint )( ( bool )value ? 1 : 0 ) );
				this.Type   = ObjectTagValueType.Bool;
			}
			else if( type == AsfTagDataType.Guid && value is Guid )
			{
				// GUID は文字列として扱う
				this._value = ( ( Guid )value ).ToByteArray();
				this.Type   = ObjectTagValueType.String;
			}
			else if( type == AsfTagDataType.String && value is string )
			{
				this._value = BinaryUtility.StringToBytesUtf16String( ( string )value );
				this.Type   = ObjectTagValueType.String;
			}
			else if( type == AsfTagDataType.UInt16 && value is ushort )
			{
				this._value = BitConverter.GetBytes( ( ushort )value );
				this.Type   = ObjectTagValueType.UInt16;
			}
			else if( type == AsfTagDataType.UInt32 && value is uint )
			{
				this._value = BitConverter.GetBytes( ( uint )value );
				this.Type   = ObjectTagValueType.UInt32;
			}
			else if( type == AsfTagDataType.UInt64 && value is ulong )
			{
				this._value = BitConverter.GetBytes( ( ulong )value );
				this.Type   = ObjectTagValueType.UInt64;
			}
			else
			{
				throw new ArgumentException( "Invalid combination of value and type." );
			}
		}

		/// <summary>
		/// タグの内容を ASF の値として取得します。
		/// </summary>
		/// <param name="type">ASF のデータ型。</param>
		/// <param name="src">タグ情報を読み込むストリーム。</param>
		/// <returns>値。type に適合するデータが存在しない場合は null 参照。</returns>
		public object Read( AsfTagDataType type, Stream src )
		{
			var value = ( this._value != null ? this._value : this._reader.Read( src ) );

			switch( type )
			{
			case AsfTagDataType.Binary: return value;
			case AsfTagDataType.Bool:   return this.ValueOfBool( value );
			case AsfTagDataType.Guid:   return this.ValueOfGuid( value );
			case AsfTagDataType.String: return this.ValueOfString( value );
			case AsfTagDataType.UInt16: return this.ValueOfUInt16( value );
			case AsfTagDataType.UInt32: return this.ValueOfUInt32( value );
			case AsfTagDataType.UInt64: return this.ValueOfUInt64( value );
			default: return null;
			}
		}

		/// <summary>
		/// 値を真偽値として取得します。
		/// </summary>
		/// <param name="value">バイト配列</param>
		/// <returns>値。型を適切に変換できない場合は null 参照。</returns>
		private bool? ValueOfBool( byte[] value )
		{
			switch( this.Type )
			{
			case ObjectTagValueType.Bool:   return BitConverter.ToBoolean( value, 0 );
			case ObjectTagValueType.UInt16: return ( BitConverter.ToUInt16( value, 0 ) != 0 );
			case ObjectTagValueType.UInt32: return ( BitConverter.ToUInt32( value, 0 ) != 0 );
			case ObjectTagValueType.UInt64: return ( BitConverter.ToUInt64( value, 0 ) != 0 );
			}

			return null;
		}

		/// <summary>
		/// 値を GUID として取得します。
		/// </summary>
		/// <param name="value">バイト配列</param>
		/// <returns>値。型を適切に変換できない場合は null 参照。</returns>
		private Guid? ValueOfGuid( byte[] value )
		{
			switch( this.Type )
			{
			case ObjectTagValueType.Binary:
				if( this.Length == 16 )
				{
					return new Guid( value );
				}
				break;

			case ObjectTagValueType.String:
				return new Guid( BinaryUtility.BytesUtf16StringToString( value ) );
			}

			return null;
		}

		/// <summary>
		/// 値を文字列として取得します。
		/// </summary>
		/// <param name="value">バイト配列</param>
		/// <returns>値。型を適切に変換できない場合は null 参照。</returns>
		private string ValueOfString( byte[] value )
		{
			switch( this.Type )
			{
			case ObjectTagValueType.Bool:
				var boolValue = this.ValueOfBool( value );
				return ( boolValue == null ? null : boolValue.ToString() );

			case ObjectTagValueType.String: return BinaryUtility.BytesUtf16StringToString( value );
			case ObjectTagValueType.UInt16: return BitConverter.ToUInt16( value, 0 ).ToString();
			case ObjectTagValueType.UInt32: return BitConverter.ToUInt32( value, 0 ).ToString();
			case ObjectTagValueType.UInt64: return BitConverter.ToUInt64( value, 0 ).ToString();
			}

			return null;
		}

		/// <summary>
		/// 値を符号なし 16 ビット整数として取得します。
		/// </summary>
		/// <returns>値。型を適切に変換できない場合は null 参照。</returns>
		private ushort? ValueOfUInt16( byte[] value )
		{
			switch( this.Type )
			{
			case ObjectTagValueType.String:
				{
					ushort result;
					if( ushort.TryParse( this.ToString(), out result ) ) { return result; }
				}
				break;

			case ObjectTagValueType.UInt16: return BitConverter.ToUInt16( value, 0 );
			case ObjectTagValueType.UInt32: return ( ushort )BitConverter.ToUInt32( value, 0 );
			case ObjectTagValueType.UInt64: return ( ushort )BitConverter.ToUInt64( value, 0 );
			}

			return null;
		}

		/// <summary>
		/// 値を符号なし 32 ビット整数として取得します。
		/// </summary>
		/// <param name="value">バイト配列</param>
		/// <returns>値。型を適切に変換できない場合は null 参照。</returns>
		private uint? ValueOfUInt32( byte[] value )
		{
			switch( this.Type )
			{
			case ObjectTagValueType.String:
				{
					uint result;
					if( uint.TryParse( this.ToString(), out result ) ) { return result; }
				}
				break;

			case ObjectTagValueType.UInt16: return BitConverter.ToUInt16( value, 0 );
			case ObjectTagValueType.UInt32: return BitConverter.ToUInt32( value, 0 );
			case ObjectTagValueType.UInt64: return ( uint )BitConverter.ToUInt64( value, 0 );
			}

			return null;
		}

		/// <summary>
		/// 値を符号なし 64 ビット整数として取得します。
		/// </summary>
		/// <param name="value">バイト配列</param>
		/// <returns>値。型を適切に変換できない場合は null 参照。</returns>
		private ulong? ValueOfUInt64( byte[] value )
		{
			switch( this.Type )
			{
			case ObjectTagValueType.String:
				{
					ulong result;
					if( ulong.TryParse( this.ToString(), out result ) ) { return result; }
				}
				break;

			case ObjectTagValueType.UInt16: return BitConverter.ToUInt16( value, 0 );
			case ObjectTagValueType.UInt32: return BitConverter.ToUInt32( value, 0 );
			case ObjectTagValueType.UInt64: return BitConverter.ToUInt64( value, 0 );
			}

			return null;
		}

		/// <summary>
		/// 値の長さを取得します。
		/// </summary>
		public int Length { get { return ( this._value == null ? this._reader.Length : this._value.Length ); } }

		/// <summary>
		/// 値の型を取得します。
		/// </summary>
		public ObjectTagValueType Type { get; private set; }

		/// <summary>
		/// オブジェクトの値を読み取るためのオブジェクト。
		/// このクラスをストリームに対する読み込みの遅延用に作成した場合、この情報が生成される。
		/// </summary>
		private ObjectTagValueReader _reader;

		/// <summary>
		/// 値のバイト配列。
		/// このクラスを値の追加用に作成した場合、この情報が生成される。
		/// </summary>
		private byte[] _value;
	}
}
