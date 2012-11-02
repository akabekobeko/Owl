
namespace Owl
{
	/// <summary>
	/// 既定のタグ情報を表します。
	/// </summary>
	public static class Tags
	{
		/// <summary>
		/// アルバムのアーティストを示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo AlbumArtist = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// アルバムの並び順を決めるための文字を示すタグ定義を取得します。
		/// </summary>
		//public static readonly TagInfo AlbumSortOrder = new TagInfo( TagValueType.String );

		/// <summary>
		/// アルバム名を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo AlbumTitle = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// アーティストを示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Artist = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// アーティストの並び順を決めるための文字を示すタグ定義を取得します。
		/// </summary>
		//public static readonly TagInfo ArtistSortOrder = new TagInfo( TagValueType.String );

		/// <summary>
		/// アーティストの公式サイト URL を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo ArtistUrl = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 音楽の使用された作品 ( 映画や TV など ) のサイト URL を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo AudioSourceURL = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// テンポ ( 1 分間の拍数 ) を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo BeatsPerMinute = new TagInfo( TagDataType.Int32, true );

		/// <summary>
		/// パッケージ化された一般的なオブジェクトを示すタグ定義を取得します。
		/// </summary>
		//public static readonly TagInfo Binary = new TagInfo( TagValueType.String );

		/// <summary>
		/// コメントを示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Comment = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 作曲者を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Composer = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 指揮者を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Conductor = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 所属するグループの情報 ( 音楽ならば CD、ビデオならばシリーズの情報など ) を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo ContentGroupDescription = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 著作者の情報を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Copyright = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 著作者の URL を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo CopyrightUrl = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 演奏時間を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Duration = new TagInfo( TagDataType.TimeSpan, false );

		/// <summary>
		/// エンコードをおこなった人を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo EncodedBy = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// エンコード設定を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo EncodingSettings = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// エンコードをおこなった時間を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo EncodingTime = new TagInfo( TagDataType.DateTime, true );

		/// <summary>
		/// ファイル サイズを示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo FileSize = new TagInfo( TagDataType.Int64, false );

		/// <summary>
		/// ジャンルを示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Genre = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 曲頭のキー ( C、Am、F♯ といった調の文字列 ) を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo InitialKey = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 国際標準レコーディングコード（ International Standard Recording Code ) を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Isrc = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 言語を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Language = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// タイムライン付きの歌詞情報を示すタグ定義を取得します。
		/// </summary>
		//public static readonly TagInfo Lyric = new TagInfo( TagValueType.String );

		/// <summary>
		/// 作詞者を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Lyricist = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 音楽 CD の識別子を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Mcdi = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// リミックスや編曲の担当者を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo ModifiedBy = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 曲の雰囲気を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Mood = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// オリジナルのアルバム、映画、ショーのタイトルを示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo OriginalAlbumTitle = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 原曲のアーティストを示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo OriginalArtist = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 元のファイル名を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo OriginalFileName = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 原曲の作詞者を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo OriginalLyricist = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 原曲のリリース年月日を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo OriginalReleaseDate = new TagInfo( TagDataType.DateTime, true );

		/// <summary>
		/// 曲の属するグループ内の番号 ( スラッシュ区切りの文字列 ) を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo PartOfSet = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 画像を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Picture = new TagInfo( TagDataType.Picture, true );

		/// <summary>
		/// プレイリスト内の曲を再生する前に必要な遅延時間 ( ミリ秒単位 ) を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo PlaylistDelay = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 曲の発行元 ( レーベル ) を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Publisher = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// ラジオ局の名前を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo RadioStationName = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// ラジオ局の所有者を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo RadioStationOwner = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// リリース年月日を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo ReleaseDate = new TagInfo( TagDataType.DateTime, true );

		/// <summary>
		/// 曲の属するアルバム、映画、ショーの副題やタイトルの補足説明を示すタグ定義を取得します。
		/// </summary>
		//public static readonly TagInfo SetSubTitle = new TagInfo( TagValueType.String );

		/// <summary>
		/// 副題やタイトルの補足説明を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo SubTitle = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// ユーザー定義のテキスト情報を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Text = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// タイトルを示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Title = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// 曲の並び順を決めるための文字を示すタグ定義を取得します。
		/// </summary>
		//public static readonly TagInfo TitleSortOrder = new TagInfo( TagValueType.String );

		/// <summary>
		/// トラック番号を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo TrackNumber = new TagInfo( TagDataType.Int32, true );

		/// <summary>
		/// ファイルの識別子を示すタグ定義を取得します。
		/// </summary>
		//public static readonly TagInfo UniqueFileIdentifier = new TagInfo( TagValueType.String );

		/// <summary>
		/// 曲の公式サイト URL を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo Url = new TagInfo( TagDataType.String, true );

		/// <summary>
		/// ユーザー定義の URL を示すタグ定義を取得します。
		/// </summary>
		public static readonly TagInfo UserWebURL = new TagInfo( TagDataType.String, true );
	}
}
