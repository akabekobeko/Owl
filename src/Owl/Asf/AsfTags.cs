﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Owl.Asf
{
	/// <summary>
	/// ASF のタグ情報を定義します。
	/// </summary>
	public static class AsfTags
	{
		/// <summary>
		/// 共通タグ情報から ASF タグ情報を取得します。
		/// </summary>
		/// <param name="tag">共通タグ情報。</param>
		/// <returns>成功時はタグ情報。それ以外は null。</returns>
		internal static AsfTagInfo GetInfo( TagInfo tag )
		{
			return InfoByCommon.ContainsKey( tag ) ? InfoByCommon[ tag ] : null;
		}

		/// <summary>
		/// 指定された名前を持つ ASF タグ情報を取得します。
		/// </summary>
		/// <param name="name">名前。</param>
		/// <returns>成功時はタグ情報。それ以外は null。</returns>
		internal static AsfTagInfo GetInfo( string name )
		{
			return InfoByName.ContainsKey( name ) ? InfoByName[ name ] : null;
		}

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo AsfLeakyBucketPairs = new AsfTagInfo( "ASFLeakyBucketPairs", AsfTagDataType.Binary );

		/// <summary>
		/// 動画ストリームにおける X 軸のアスペクト比。
		/// </summary>
		public static readonly AsfTagInfo AspectRatioX = new AsfTagInfo( "AspectRatioX", AsfTagDataType.UInt32 );

		/// <summary>
		/// 動画ストリームにおける Y 軸のアスペクト比。
		/// </summary>
		public static readonly AsfTagInfo AspectRatioY = new AsfTagInfo( "AspectRatioY", AsfTagDataType.UInt32 );

		/// <summary>
		/// アーティスト。
		/// </summary>
		public static readonly AsfTagInfo Author = new AsfTagInfo( "Author", AsfTagDataType.String, true, HeaderObjectType.ContentDescription );

		/// <summary>
		/// 音量の平均値。
		/// </summary>
		public static readonly AsfTagInfo AverageLevel = new AsfTagInfo( "AverageLevel", AsfTagDataType.UInt32, true, HeaderObjectType.ContentDescription );

		/// <summary>
		/// バナー画像。
		/// </summary>
		public static readonly AsfTagInfo BannerImageData = new AsfTagInfo( "BannerImageData", AsfTagDataType.Binary );

		/// <summary>
		/// バナー画像の種別。
		/// </summary>
		public static readonly AsfTagInfo BannerImageType = new AsfTagInfo( "BannerImageType", AsfTagDataType.UInt32 );

		/// <summary>
		/// バナー画像の URL。
		/// </summary>
		public static readonly AsfTagInfo BannerImageUrl = new AsfTagInfo( "BannerImageURL", AsfTagDataType.String );

		/// <summary>
		/// 平均ビットレート。
		/// </summary>
		public static readonly AsfTagInfo Bitrate = new AsfTagInfo( "Bitrate", AsfTagDataType.UInt32 );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo Broadcast = new AsfTagInfo( "Broadcast", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo BufferAverage = new AsfTagInfo( "BufferAverage", AsfTagDataType.UInt32 );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo CanSkipBackward = new AsfTagInfo( "Can_Skip_Backward", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo CanSkipForward = new AsfTagInfo( "Can_Skip_Forward", AsfTagDataType.Bool );

		/// <summary>
		/// 著作権情報。
		/// </summary>
		public static readonly AsfTagInfo Copyright = new AsfTagInfo( "Copyright", AsfTagDataType.String, true, HeaderObjectType.ContentDescription );

		/// <summary>
		/// 著作権情報の URL。
		/// </summary>
		public static readonly AsfTagInfo CopyrightUrl = new AsfTagInfo( "CopyrightURL", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo CurrentBitrate = new AsfTagInfo( "CurrentBitrate", AsfTagDataType.UInt32 );

		/// <summary>
		/// コメント。
		/// </summary>
		public static readonly AsfTagInfo Description = new AsfTagInfo( "Description", AsfTagDataType.String, true, HeaderObjectType.ContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmContentId = new AsfTagInfo( "DRM_ContentID", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmDrmHeaderContentDistributor = new AsfTagInfo( "DRM_DRMHeader_ContentDistributor", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmDrmHeaderContentId = new AsfTagInfo( "DRM_DRMHeader_ContentID", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmDrmHeaderIndividualizedVersion = new AsfTagInfo( "DRM_DRMHeader_IndividualizedVersion", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmDrmHeaderKeyId = new AsfTagInfo( "DRM_DRMHeader_KeyID", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmDrmHeaderLicenseAcqUrl = new AsfTagInfo( "DRM_DRMHeader_LicenseAcqURL", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmDrmHeaderSubscriptionContentId = new AsfTagInfo( "DRM_DRMHeader_SubscriptionContentID", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmDrmHeader = new AsfTagInfo( "DRM_DRMHeader", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmIndividualizedVersion = new AsfTagInfo( "DRM_IndividualizedVersion", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmKeyId = new AsfTagInfo( "DRM_KeyID", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmLaSignatureCert = new AsfTagInfo( "DRM_LASignatureCert", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmLaSignatureLicSrvCert = new AsfTagInfo( "DRM_LASignatureLicSrvCert", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmLaSignaturePrivKey = new AsfTagInfo( "DRM_LASignaturePrivKey", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmLaSignatureRootCert = new AsfTagInfo( "DRM_LASignatureRootCert", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmLicenseAcqUrl = new AsfTagInfo( "DRM_LicenseAcqURL", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmLicenseId = new AsfTagInfo( "DRM_LicenseID", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmSourceId = new AsfTagInfo( "DRM_SourceID", AsfTagDataType.UInt32 );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo DrmV1LicenseAcqUrl = new AsfTagInfo( "DRM_V1LicenseAcqURL", AsfTagDataType.String );

		/// <summary>
		/// 演奏時間。
		/// </summary>
		public static readonly AsfTagInfo Duration = new AsfTagInfo( "Duration", AsfTagDataType.UInt64, false, HeaderObjectType.FileProperties );

		/// <summary>
		/// ファイル サイズ。
		/// </summary>
		public static readonly AsfTagInfo FileSize = new AsfTagInfo( "FileSize", AsfTagDataType.UInt64, false, HeaderObjectType.FileProperties );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo HasArbitraryDataStream = new AsfTagInfo( "HasArbitraryDataStream", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo HasAttachedImages = new AsfTagInfo( "HasAttachedImages", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo HasAudio = new AsfTagInfo( "HasAudio", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo HasFileTransferStream = new AsfTagInfo( "HasFileTransferStream", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo HasImage = new AsfTagInfo( "HasImage", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo HasScript = new AsfTagInfo( "HasScript", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo HasVideo = new AsfTagInfo( "HasVideo", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo IsProtected = new AsfTagInfo( "Is_Protected", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo IsTrusted = new AsfTagInfo( "Is_Trusted", AsfTagDataType.Bool );

		/// <summary>
		/// 国際標準視聴覚番号 ( International Standard Audiovisual Number ) 。
		/// </summary>
		public static readonly AsfTagInfo Isan = new AsfTagInfo( "WM/ISAN", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 可変ビットレートでエンコードされたこと。
		/// </summary>
		public static readonly AsfTagInfo IsVBR = new AsfTagInfo( "IsVBR", AsfTagDataType.Bool, false, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo NscAddress = new AsfTagInfo( "NSC_Address", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo NscDescription = new AsfTagInfo( "NSC_Description", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo NscEmail = new AsfTagInfo( "NSC_Email", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo NscName = new AsfTagInfo( "NSC_Name", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo NscPhone = new AsfTagInfo( "NSC_Phone", AsfTagDataType.String );

		/// <summary>
		/// 動画ストリームのフレーム数。
		/// </summary>
		public static readonly AsfTagInfo NumberOfFrames = new AsfTagInfo( "NumberOfFrames", AsfTagDataType.UInt64, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo OptimalBitrate = new AsfTagInfo( "OptimalBitrate", AsfTagDataType.UInt32 );

		/// <summary>
		/// 音量の最大値。
		/// </summary>
		public static readonly AsfTagInfo PeakValue = new AsfTagInfo( "PeakValue", AsfTagDataType.UInt32, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 保護者による制限。
		/// </summary>
		public static readonly AsfTagInfo Rating = new AsfTagInfo( "Rating", AsfTagDataType.String, true, HeaderObjectType.ContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo Seekable = new AsfTagInfo( "Seekable", AsfTagDataType.Bool );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo Signature_Name = new AsfTagInfo( "Signature_Name", AsfTagDataType.String );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo Stridable = new AsfTagInfo( "Stridable", AsfTagDataType.Bool );

		/// <summary>
		/// タイトル。
		/// </summary>
		public static readonly AsfTagInfo Title = new AsfTagInfo( "Title", AsfTagDataType.String, true, HeaderObjectType.ContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo VbrPeak = new AsfTagInfo( "VBRPeak", AsfTagDataType.UInt32 );

		/// <summary>
		/// アルバムのアーティスト名。
		/// </summary>
		public static readonly AsfTagInfo AlbumArtist = new AsfTagInfo( "WM/AlbumArtist", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// アルバムのジャケット画像に関する情報サイトの URL 。
		/// </summary>
		public static readonly AsfTagInfo AlbumCoverUrl = new AsfTagInfo( "WM/AlbumCoverURL", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// アルバム名。
		/// </summary>
		public static readonly AsfTagInfo AlbumTitle = new AsfTagInfo( "WM/AlbumTitle", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo AsfPacketCount = new AsfTagInfo( "WM/ASFPacketCount", AsfTagDataType.UInt64 );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo AsfSecurityObjectsSize = new AsfTagInfo( "WM/ASFSecurityObjectsSize", AsfTagDataType.UInt64 );

		/// <summary>
		/// 音楽ファイルのサイト ( アルバムやアーティスト情報 ) URL 。
		/// </summary>
		public static readonly AsfTagInfo AudioFileUrl = new AsfTagInfo( "WM/AudioFileURL", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 音楽の使用された作品 ( 映画や TV など ) のサイトへの URL 。
		/// </summary>
		public static readonly AsfTagInfo AudioSourceUrl = new AsfTagInfo( "WM/AudioSourceURL", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// アーティストの URL 。
		/// </summary>
		public static readonly AsfTagInfo AuthorUrl = new AsfTagInfo( "WM/AuthorURL", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// テンポ ( 1 分間の拍数 ) 。
		/// </summary>
		public static readonly AsfTagInfo BeatsPerMinute = new AsfTagInfo( "WM/BeatsPerMinute", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// カテゴリ。
		/// </summary>
		public static readonly AsfTagInfo Category = new AsfTagInfo( "WM/Category", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo Codec = new AsfTagInfo( "WM/Codec", AsfTagDataType.String );

		/// <summary>
		/// 作曲者。
		/// </summary>
		public static readonly AsfTagInfo Composer = new AsfTagInfo( "WM/Composer", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 指揮者。
		/// </summary>
		public static readonly AsfTagInfo Conductor = new AsfTagInfo( "WM/Conductor", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo ContainerFormat = new AsfTagInfo( "WM/ContainerFormat", AsfTagDataType.Binary );

		/// <summary>
		/// ファイルの提供者。
		/// </summary>
		public static readonly AsfTagInfo ContentDistributor = new AsfTagInfo( "WM/ContentDistributor", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 所属するグループの情報 ( 音楽ならば CD、ビデオならばシリーズの情報など ) 。
		/// </summary>
		public static readonly AsfTagInfo ContentGroupDescription = new AsfTagInfo( "WM/ContentGroupDescription", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ディレクター。
		/// </summary>
		public static readonly AsfTagInfo Director = new AsfTagInfo( "WM/Director", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// DRM で保護されていることを示す情報。
		/// </summary>
		public static readonly AsfTagInfo Drm = new AsfTagInfo( "WM/DRM", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// DVD の識別子。
		/// </summary>
		public static readonly AsfTagInfo DvdId = new AsfTagInfo( "WM/DVDID", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// エンコードをおこなった人。
		/// </summary>
		public static readonly AsfTagInfo EncodedBy = new AsfTagInfo( "WM/EncodedBy", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// エンコード設定。
		/// </summary>
		public static readonly AsfTagInfo EncodingSettings = new AsfTagInfo( "WM/EncodingSettings", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// エンコードをおこなった時間。
		/// </summary>
		public static readonly AsfTagInfo EncodingTime = new AsfTagInfo( "WM/EncodingTime", AsfTagDataType.UInt64, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ジャンル。
		/// </summary>
		public static readonly AsfTagInfo Genre = new AsfTagInfo( "WM/Genre", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ジャンル ID 。
		/// この情報は ID3v2 の TCON タグに準拠しています。
		/// 通常、"(17) Rock" のように、括弧にジャンルを表す数値を入れ、後続の文字列にジャンル名を格納します。
		/// 詳細は ID3v2 の仕様を参照してください。
		/// </summary>
		public static readonly AsfTagInfo GenreId = new AsfTagInfo( "WM/GenreID", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 曲頭のキー ( C、Am、F♯ といった調の文字列 ) 。
		/// </summary>
		public static readonly AsfTagInfo InitialKey = new AsfTagInfo( "WM/InitialKey", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 国際標準レコーディングコード（ International Standard Recording Code ) 。
		/// </summary>
		public static readonly AsfTagInfo Isrc = new AsfTagInfo( "WM/ISRC", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 言語。
		/// </summary>
		public static readonly AsfTagInfo Language = new AsfTagInfo( "WM/Language", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 歌詞。
		/// </summary>
		public static readonly AsfTagInfo Lyrics = new AsfTagInfo( "WM/Lyrics", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// タイムライン付きの歌詞情報。
		/// </summary>
		public static readonly AsfTagInfo LyricsSynchronised = new AsfTagInfo( "WM/Lyrics_Synchronised", AsfTagDataType.Binary, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 音楽 CD の識別子。
		/// </summary>
		public static readonly AsfTagInfo Mcdi = new AsfTagInfo( "WM/MCDI", AsfTagDataType.Binary, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo MediaClassPrimaryId = new AsfTagInfo( "WM/MediaClassPrimaryID", AsfTagDataType.Guid );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo MediaClassSecondaryId = new AsfTagInfo( "WM/MediaClassSecondaryID", AsfTagDataType.Guid );

		/// <summary>
		/// 放送をおこなったメディア名。
		/// </summary>
		public static readonly AsfTagInfo MediaCredits = new AsfTagInfo( "WM/MediaCredits", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 放送時におけるテープ遅延の有無。
		/// </summary>
		public static readonly AsfTagInfo MediaIsDelay = new AsfTagInfo( "WM/MediaIsDelay", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// シリーズの最終回であること。
		/// </summary>
		public static readonly AsfTagInfo MediaIsFinale = new AsfTagInfo( "WM/MediaIsFinale", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 生放送であること。
		/// </summary>
		public static readonly AsfTagInfo MediaIsLive = new AsfTagInfo( "WM/MediaIsLive", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// シリーズの初回であること。
		/// </summary>
		public static readonly AsfTagInfo MediaIsPremiere = new AsfTagInfo( "WM/MediaIsPremiere", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 再放送であること。
		/// </summary>
		public static readonly AsfTagInfo MediaIsRepeat = new AsfTagInfo( "WM/MediaIsRepeat", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 音声多重放送 ( Second Audio Program ) であること。
		/// </summary>
		public static readonly AsfTagInfo MediaIsSap = new AsfTagInfo( "WM/MediaIsSAP", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ステレオ放送であること。
		/// </summary>
		public static readonly AsfTagInfo MediaIsStereo = new AsfTagInfo( "WM/MediaIsStereo", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 字幕を持つこと。
		/// </summary>
		public static readonly AsfTagInfo MediaIsSubtitled = new AsfTagInfo( "WM/MediaIsSubtitled", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 収録放送されたこと。
		/// </summary>
		public static readonly AsfTagInfo MediaIsTape = new AsfTagInfo( "WM/MediaIsTape", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// コンテンツ配信をおこなうネットワーク情報。
		/// </summary>
		public static readonly AsfTagInfo MediaNetworkAffiliation = new AsfTagInfo( "WM/MediaNetworkAffiliation", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 放送日時。
		/// </summary>
		public static readonly AsfTagInfo MediaOriginalBroadcastDateTime = new AsfTagInfo( "WM/MediaOriginalBroadcastDateTime", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 放送したチャンネル。
		/// </summary>
		public static readonly AsfTagInfo MediaOriginalChannel = new AsfTagInfo( "WM/MediaOriginalChannel", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 放送局の識別信号。
		/// </summary>
		public static readonly AsfTagInfo MediaStationCallSign = new AsfTagInfo( "WM/MediaStationCallSign", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 放送局の名前。
		/// </summary>
		public static readonly AsfTagInfo MediaStationName = new AsfTagInfo( "WM/MediaStationName", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ファイルを更新したグループ、または個人名。
		/// </summary>
		public static readonly AsfTagInfo ModifiedBy = new AsfTagInfo( "WM/ModifiedBy", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 曲の雰囲気。
		/// </summary>
		public static readonly AsfTagInfo Mood = new AsfTagInfo( "WM/Mood", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 曲の初出となるアルバム。
		/// </summary>
		public static readonly AsfTagInfo OriginalAlbumTitle = new AsfTagInfo( "WM/OriginalAlbumTitle", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 原曲のアーティスト。
		/// </summary>
		public static readonly AsfTagInfo OriginalArtist = new AsfTagInfo( "WM/OriginalArtist", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 元のファイル名。
		/// </summary>
		public static readonly AsfTagInfo OriginalFilename = new AsfTagInfo( "WM/OriginalFilename", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 原曲の作詞者。
		/// </summary>
		public static readonly AsfTagInfo OriginalLyricist = new AsfTagInfo( "WM/OriginalLyricist", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 原曲がリリースされた時間。
		/// </summary>
		public static readonly AsfTagInfo OriginalReleaseTime = new AsfTagInfo( "WM/OriginalReleaseTime", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 原曲がリリースされた年。
		/// </summary>
		public static readonly AsfTagInfo OriginalReleaseYear = new AsfTagInfo( "WM/OriginalReleaseYear", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 保護者による制限。
		/// </summary>
		public static readonly AsfTagInfo ParentalRating = new AsfTagInfo( "WM/ParentalRating", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 保護者による制限の理由。
		/// </summary>
		public static readonly AsfTagInfo ParentalRatingReason = new AsfTagInfo( "WM/ParentalRatingReason", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 曲の属するグループ内の番号 ( スラッシュ区切りの文字列 ) 。
		/// 複数枚や複数の組曲で構成されるアルバムの場合、それらの総数と何番目に位置するかを表します。
		/// 例えば 3 枚組のアルバムにおいて、2 枚目に属する曲ならば "2/3" となります。
		/// </summary>
		public static readonly AsfTagInfo PartOfSet = new AsfTagInfo( "WM/PartOfSet", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo PeakBitrate = new AsfTagInfo( "WM/PeakBitrate", AsfTagDataType.UInt32 );

		/// <summary>
		/// 音楽の年代。
		/// 例えばバロックやルネッサンスなど、ある時代を指すために使用します。
		/// </summary>
		public static readonly AsfTagInfo Period = new AsfTagInfo( "WM/Period", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 曲を表す画像。
		/// </summary>
		public static readonly AsfTagInfo Picture = new AsfTagInfo( "WM/Picture", AsfTagDataType.Binary );

		/// <summary>
		/// プレイリスト内の曲を再生する前に必要な遅延時間 ( ミリ秒単位 ) 。
		/// </summary>
		public static readonly AsfTagInfo PlaylistDelay = new AsfTagInfo( "WM/PlaylistDelay", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// プロデューサー。
		/// </summary>
		public static readonly AsfTagInfo Producer = new AsfTagInfo( "WM/Producer", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// プロモーション用の URL 。
		/// </summary>
		public static readonly AsfTagInfo PromotionUrl = new AsfTagInfo( "WM/PromotionURL", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// コンテンツを保護する方法の種別。
		/// </summary>
		public static readonly AsfTagInfo ProtectionType = new AsfTagInfo( "WM/ProtectionType", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// メタデータ提供サービス ( CDDB や AMG など ) 。
		/// </summary>
		public static readonly AsfTagInfo Provider = new AsfTagInfo( "WM/Provider", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// コンテンツを配信するプロパイダの著作権情報。
		/// </summary>
		public static readonly AsfTagInfo ProviderCopyright = new AsfTagInfo( "WM/ProviderCopyright", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// メタデータ提供サービスによる評価。
		/// </summary>
		public static readonly AsfTagInfo ProviderRating = new AsfTagInfo( "WM/ProviderRating", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// メタデータ提供サービスによるスタイル ( 副次的なジャンル ) 指定。
		/// </summary>
		public static readonly AsfTagInfo ProviderStyle = new AsfTagInfo( "WM/ProviderStyle", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 曲の発行元 ( レーベル ) 。
		/// </summary>
		public static readonly AsfTagInfo Publisher = new AsfTagInfo( "WM/Publisher", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ラジオ局の名前。
		/// </summary>
		public static readonly AsfTagInfo RadioStationName = new AsfTagInfo( "WM/RadioStationName", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ラジオ局の所有者。
		/// </summary>
		public static readonly AsfTagInfo RadioStationOwner = new AsfTagInfo( "WM/RadioStationOwner", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 複数のユーザーによる評価。
		/// </summary>
		public static readonly AsfTagInfo SharedUserRating = new AsfTagInfo( "WM/SharedUserRating", AsfTagDataType.UInt32, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo StreamTypeInfo = new AsfTagInfo( "WM/StreamTypeInfo", AsfTagDataType.Binary );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo SubscriptionContentId = new AsfTagInfo( "WM/SubscriptionContentID", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 副題。
		/// </summary>
		public static readonly AsfTagInfo SubTitle = new AsfTagInfo( "WM/SubTitle", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 副題の補足情報。
		/// </summary>
		public static readonly AsfTagInfo SubTitleDescription = new AsfTagInfo( "WM/SubTitleDescription", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ユーザー定義のテキスト情報。
		/// </summary>
		public static readonly AsfTagInfo Text = new AsfTagInfo( "WM/Text", AsfTagDataType.Binary );

		/// <summary>
		/// ファイル作成に使用したツール。
		/// </summary>
		public static readonly AsfTagInfo ToolName = new AsfTagInfo( "WM/ToolName", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ファイル作成に使用したツールのバージョン情報。
		/// </summary>
		public static readonly AsfTagInfo ToolVersion = new AsfTagInfo( "WM/ToolVersion", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// トラック番号 ( 0 から開始 ) 。
		/// このデータは下位互換のために残されており、現在は WmTrackNumber を代りに使用します。
		/// </summary>
		public static readonly AsfTagInfo Track = new AsfTagInfo( "WM/Track", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// トラック番号 ( 1 から開始 ) 。
		/// </summary>
		public static readonly AsfTagInfo TrackNumber = new AsfTagInfo( "WM/TrackNumber", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ファイルの識別子 ( セミコロンで区切られた任意の値 ) 。
		/// </summary>
		public static readonly AsfTagInfo UniqueFileIdentifier = new AsfTagInfo( "WM/UniqueFileIdentifier", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ユーザー定義の URL 情報
		/// </summary>
		public static readonly AsfTagInfo UserWebUrl = new AsfTagInfo( "WM/UserWebURL", AsfTagDataType.Binary );

		/// <summary>
		/// クローズドキャプションを含むこと。
		/// </summary>
		public static readonly AsfTagInfo VideoClosedCaptioning = new AsfTagInfo( "WM/VideoClosedCaptioning", AsfTagDataType.Bool, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ビデオのフレームレート
		/// </summary>
		public static readonly AsfTagInfo VideoFrameRate = new AsfTagInfo( "WM/VideoFrameRate", AsfTagDataType.UInt32, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ビデオの高さ ( ピクセル単位 ) 。
		/// </summary>
		public static readonly AsfTagInfo VideoHeight = new AsfTagInfo( "WM/VideoHeight", AsfTagDataType.UInt32, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// ビデオの幅 ( ピクセル単位 ) 。
		/// </summary>
		public static readonly AsfTagInfo VideoWidth = new AsfTagInfo( "WM/VideoWidth", AsfTagDataType.UInt32, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo WmaDrcAverageReference = new AsfTagInfo( "WM/WMADRCAverageReference", AsfTagDataType.UInt32 );

		/// <summary>
		/// 平均音量レベル。
		/// </summary>
		public static readonly AsfTagInfo WmaDrcAverageTarget = new AsfTagInfo( "WM/WMADRCAverageTarget", AsfTagDataType.UInt32, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo WmaDrcPeakReference = new AsfTagInfo( "WM/WMADRCPeakReference", AsfTagDataType.UInt32 );

		/// <summary>
		/// 最大音量レベル。
		/// </summary>
		public static readonly AsfTagInfo WmaDrcPeakTarget = new AsfTagInfo( "WM/WMADRCPeakTarget", AsfTagDataType.UInt32, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo WmCollectionGroupId = new AsfTagInfo( "WM/WMCollectionGroupID", AsfTagDataType.Guid );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo WmCollectionId = new AsfTagInfo( "WM/WMCollectionID", AsfTagDataType.Guid );

		/// <summary>
		/// 
		/// </summary>
		public static readonly AsfTagInfo WmContentId = new AsfTagInfo( "WM/WMContentID", AsfTagDataType.Guid );

		/// <summary>
		/// 元ファイルの著作権保護方法。
		/// </summary>
		public static readonly AsfTagInfo WmShadowFileSourceDrmType = new AsfTagInfo( "WM/WMShadowFileSourceDRMType", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 元ファイルの種別。
		/// </summary>
		public static readonly AsfTagInfo WmShadowFileSourceFileType = new AsfTagInfo( "WM/WMShadowFileSourceFileType", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 作詞者。
		/// </summary>
		public static readonly AsfTagInfo Writer = new AsfTagInfo( "WM/Writer", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// リリースされた年。
		/// </summary>
		public static readonly AsfTagInfo Year = new AsfTagInfo( "WM/Year", AsfTagDataType.String, true, HeaderObjectType.ExtendedContentDescription );

		/// <summary>
		/// 汎用タグ定義から ASF のタグ定義を取得するためのディクショナリ。
		/// </summary>
		private static readonly Dictionary< TagInfo, AsfTagInfo > InfoByCommon = new Dictionary< TagInfo, AsfTagInfo >()
		{
			{ Tags.AlbumArtist,             AsfTags.AlbumArtist             },
			{ Tags.AlbumTitle,              AsfTags.AlbumTitle              },
			{ Tags.Artist,                  AsfTags.Author                  },
			{ Tags.ArtistUrl,               AsfTags.AuthorUrl               },
			{ Tags.AudioSourceURL,          AsfTags.AudioSourceUrl          },
			{ Tags.BeatsPerMinute,          AsfTags.BeatsPerMinute          },
			{ Tags.Comment,                 AsfTags.Description             },
			{ Tags.Composer,                AsfTags.Composer                },
			{ Tags.Conductor,               AsfTags.Conductor               },
			{ Tags.ContentGroupDescription, AsfTags.ContentGroupDescription },
			{ Tags.Copyright,               AsfTags.Copyright               },
			{ Tags.CopyrightUrl,            AsfTags.CopyrightUrl            },
			{ Tags.Duration,                AsfTags.Duration                },
			{ Tags.EncodedBy,               AsfTags.EncodedBy               },
			{ Tags.EncodingSettings,        AsfTags.EncodingSettings        },
			{ Tags.EncodingTime,            AsfTags.EncodingTime            },
			{ Tags.FileSize,                AsfTags.FileSize                },
			{ Tags.Genre,                   AsfTags.Genre                   },
			{ Tags.InitialKey,              AsfTags.InitialKey              },
			{ Tags.Isrc,                    AsfTags.Isrc                    },
			{ Tags.Language,                AsfTags.Language                },
			{ Tags.Lyricist,                AsfTags.Writer                  },
			{ Tags.Mcdi,                    AsfTags.Mcdi                    },
			{ Tags.ModifiedBy,              AsfTags.ModifiedBy              },
			{ Tags.Mood,                    AsfTags.Mood                    },
			{ Tags.OriginalAlbumTitle,      AsfTags.OriginalAlbumTitle      },
			{ Tags.OriginalArtist,          AsfTags.OriginalArtist          },
			{ Tags.OriginalFileName,        AsfTags.OriginalFilename        },
			{ Tags.OriginalLyricist,        AsfTags.OriginalLyricist        },
			{ Tags.OriginalReleaseDate,     AsfTags.OriginalReleaseYear     },
			{ Tags.PartOfSet,               AsfTags.PartOfSet               },
			{ Tags.Picture,                 AsfTags.Picture                 },
			{ Tags.PlaylistDelay,           AsfTags.PlaylistDelay           },
			{ Tags.Publisher,               AsfTags.Publisher               },
			{ Tags.RadioStationName,        AsfTags.RadioStationName        },
			{ Tags.RadioStationOwner,       AsfTags.RadioStationOwner       },
			{ Tags.ReleaseDate,             AsfTags.Year                    },
			{ Tags.SubTitle,                AsfTags.SubTitle                },
			{ Tags.Text,                    AsfTags.Text                    },
			{ Tags.Title,                   AsfTags.Title                   },
			{ Tags.TrackNumber,             AsfTags.TrackNumber             },
			{ Tags.Url,                     AsfTags.AudioFileUrl            },
			{ Tags.UserWebURL,              AsfTags.UserWebUrl              }
		};

		/// <summary>
		/// タグ名をキーとするタグ情報のディクショナリ。
		/// </summary>
		private static readonly Dictionary< string, AsfTagInfo > InfoByName = new Dictionary<string, AsfTagInfo>()
		{
			{ AsfTags.AsfLeakyBucketPairs.Name,               AsfTags.AsfLeakyBucketPairs               },
			{ AsfTags.AspectRatioX.Name,                      AsfTags.AspectRatioX                      },
			{ AsfTags.AspectRatioY.Name,                      AsfTags.AspectRatioY                      },
			{ AsfTags.Author.Name,                            AsfTags.Author                            },
			{ AsfTags.AverageLevel.Name,                      AsfTags.AverageLevel                      },
			{ AsfTags.BannerImageData.Name,                   AsfTags.BannerImageData                   },
			{ AsfTags.BannerImageType.Name,                   AsfTags.BannerImageType                   },
			{ AsfTags.BannerImageUrl.Name,                    AsfTags.BannerImageUrl                    },
			{ AsfTags.Bitrate.Name,                           AsfTags.Bitrate                           },
			{ AsfTags.Broadcast.Name,                         AsfTags.Broadcast                         },
			{ AsfTags.BufferAverage.Name,                     AsfTags.BufferAverage                     },
			{ AsfTags.CanSkipBackward.Name,                   AsfTags.CanSkipBackward                   },
			{ AsfTags.CanSkipForward.Name,                    AsfTags.CanSkipForward                    },
			{ AsfTags.Copyright.Name,                         AsfTags.Copyright                         },
			{ AsfTags.CopyrightUrl.Name,                      AsfTags.CopyrightUrl                      },
			{ AsfTags.CurrentBitrate.Name,                    AsfTags.CurrentBitrate                    },
			{ AsfTags.Description.Name,                       AsfTags.Description                       },
			{ AsfTags.DrmContentId.Name,                      AsfTags.DrmContentId                      },
			{ AsfTags.DrmDrmHeaderContentDistributor.Name,    AsfTags.DrmDrmHeaderContentDistributor    },
			{ AsfTags.DrmDrmHeaderContentId.Name,             AsfTags.DrmDrmHeaderContentId             },
			{ AsfTags.DrmDrmHeaderIndividualizedVersion.Name, AsfTags.DrmDrmHeaderIndividualizedVersion },
			{ AsfTags.DrmDrmHeaderKeyId.Name,                 AsfTags.DrmDrmHeaderKeyId                 },
			{ AsfTags.DrmDrmHeaderLicenseAcqUrl.Name,         AsfTags.DrmDrmHeaderLicenseAcqUrl         },
			{ AsfTags.DrmDrmHeaderSubscriptionContentId.Name, AsfTags.DrmDrmHeaderSubscriptionContentId },
			{ AsfTags.DrmDrmHeader.Name,                      AsfTags.DrmDrmHeader                      },
			{ AsfTags.DrmIndividualizedVersion.Name,          AsfTags.DrmIndividualizedVersion          },
			{ AsfTags.DrmKeyId.Name,                          AsfTags.DrmKeyId                          },
			{ AsfTags.DrmLaSignatureCert.Name,                AsfTags.DrmLaSignatureCert                },
			{ AsfTags.DrmLaSignatureLicSrvCert.Name,          AsfTags.DrmLaSignatureLicSrvCert          },
			{ AsfTags.DrmLaSignaturePrivKey.Name,             AsfTags.DrmLaSignaturePrivKey             },
			{ AsfTags.DrmLaSignatureRootCert.Name,            AsfTags.DrmLaSignatureRootCert            },
			{ AsfTags.DrmLicenseAcqUrl.Name,                  AsfTags.DrmLicenseAcqUrl                  },
			{ AsfTags.DrmLicenseId.Name,                      AsfTags.DrmLicenseId                      },
			{ AsfTags.DrmSourceId.Name,                       AsfTags.DrmSourceId                       },
			{ AsfTags.DrmV1LicenseAcqUrl.Name,                AsfTags.DrmV1LicenseAcqUrl                },
			{ AsfTags.Duration.Name,                          AsfTags.Duration                          },
			{ AsfTags.FileSize.Name,                          AsfTags.FileSize                          },
			{ AsfTags.HasArbitraryDataStream.Name,            AsfTags.HasArbitraryDataStream            },
			{ AsfTags.HasAttachedImages.Name,                 AsfTags.HasAttachedImages                 },
			{ AsfTags.HasAudio.Name,                          AsfTags.HasAudio                          },
			{ AsfTags.HasFileTransferStream.Name,             AsfTags.HasFileTransferStream             },
			{ AsfTags.HasImage.Name,                          AsfTags.HasImage                          },
			{ AsfTags.HasScript.Name,                         AsfTags.HasScript                         },
			{ AsfTags.HasVideo.Name,                          AsfTags.HasVideo                          },
			{ AsfTags.IsProtected.Name,                       AsfTags.IsProtected                       },
			{ AsfTags.IsTrusted.Name,                         AsfTags.IsTrusted                         },
			{ AsfTags.Isan.Name,                              AsfTags.Isan                              },
			{ AsfTags.IsVBR.Name,                             AsfTags.IsVBR                             },
			{ AsfTags.NscAddress.Name,                        AsfTags.NscAddress                        },
			{ AsfTags.NscDescription.Name,                    AsfTags.NscDescription                    },
			{ AsfTags.NscEmail.Name,                          AsfTags.NscEmail                          },
			{ AsfTags.NscName.Name,                           AsfTags.NscName                           },
			{ AsfTags.NscPhone.Name,                          AsfTags.NscPhone                          },
			{ AsfTags.NumberOfFrames.Name,                    AsfTags.NumberOfFrames                    },
			{ AsfTags.OptimalBitrate.Name,                    AsfTags.OptimalBitrate                    },
			{ AsfTags.PeakValue.Name,                         AsfTags.PeakValue                         },
			{ AsfTags.Rating.Name,                            AsfTags.Rating                            },
			{ AsfTags.Seekable.Name,                          AsfTags.Seekable                          },
			{ AsfTags.Signature_Name.Name,                    AsfTags.Signature_Name                    },
			{ AsfTags.Stridable.Name,                         AsfTags.Stridable                         },
			{ AsfTags.Title.Name,                             AsfTags.Title                             },
			{ AsfTags.VbrPeak.Name,                           AsfTags.VbrPeak                           },
			{ AsfTags.AlbumArtist.Name,                       AsfTags.AlbumArtist                     },
			{ AsfTags.AlbumCoverUrl.Name,                     AsfTags.AlbumCoverUrl                   },
			{ AsfTags.AlbumTitle.Name,                        AsfTags.AlbumTitle                      },
			{ AsfTags.AsfPacketCount.Name,                    AsfTags.AsfPacketCount                  },
			{ AsfTags.AsfSecurityObjectsSize.Name,            AsfTags.AsfSecurityObjectsSize          },
			{ AsfTags.AudioFileUrl.Name,                      AsfTags.AudioFileUrl                    },
			{ AsfTags.AudioSourceUrl.Name,                    AsfTags.AudioSourceUrl                  },
			{ AsfTags.AuthorUrl.Name,                         AsfTags.AuthorUrl                       },
			{ AsfTags.BeatsPerMinute.Name,                    AsfTags.BeatsPerMinute                  },
			{ AsfTags.Category.Name,                          AsfTags.Category                        },
			{ AsfTags.Codec.Name,                             AsfTags.Codec                           },
			{ AsfTags.Composer.Name,                          AsfTags.Composer                        },
			{ AsfTags.Conductor.Name,                         AsfTags.Conductor                       },
			{ AsfTags.ContainerFormat.Name,                   AsfTags.ContainerFormat                 },
			{ AsfTags.ContentDistributor.Name,                AsfTags.ContentDistributor              },
			{ AsfTags.ContentGroupDescription.Name,           AsfTags.ContentGroupDescription         },
			{ AsfTags.Director.Name,                          AsfTags.Director                        },
			{ AsfTags.Drm.Name,                               AsfTags.Drm                             },
			{ AsfTags.DvdId.Name,                             AsfTags.DvdId                           },
			{ AsfTags.EncodedBy.Name,                         AsfTags.EncodedBy                       },
			{ AsfTags.EncodingSettings.Name,                AsfTags.EncodingSettings                },
			{ AsfTags.EncodingTime.Name,                    AsfTags.EncodingTime                    },
			{ AsfTags.Genre.Name,                           AsfTags.Genre                           },
			{ AsfTags.GenreId.Name,                         AsfTags.GenreId                         },
			{ AsfTags.InitialKey.Name,                      AsfTags.InitialKey                      },
			{ AsfTags.Isrc.Name,                            AsfTags.Isrc                            },
			{ AsfTags.Language.Name,                        AsfTags.Language                        },
			{ AsfTags.Lyrics.Name,                          AsfTags.Lyrics                          },
			{ AsfTags.LyricsSynchronised.Name,              AsfTags.LyricsSynchronised              },
			{ AsfTags.Mcdi.Name,                            AsfTags.Mcdi                            },
			{ AsfTags.MediaClassPrimaryId.Name,             AsfTags.MediaClassPrimaryId             },
			{ AsfTags.MediaClassSecondaryId.Name,           AsfTags.MediaClassSecondaryId           },
			{ AsfTags.MediaCredits.Name,                    AsfTags.MediaCredits                    },
			{ AsfTags.MediaIsDelay.Name,                    AsfTags.MediaIsDelay                    },
			{ AsfTags.MediaIsFinale.Name,                   AsfTags.MediaIsFinale                   },
			{ AsfTags.MediaIsLive.Name,                     AsfTags.MediaIsLive                     },
			{ AsfTags.MediaIsPremiere.Name,                 AsfTags.MediaIsPremiere                 },
			{ AsfTags.MediaIsRepeat.Name,                   AsfTags.MediaIsRepeat                   },
			{ AsfTags.MediaIsSap.Name,                      AsfTags.MediaIsSap                      },
			{ AsfTags.MediaIsStereo.Name,                   AsfTags.MediaIsStereo                   },
			{ AsfTags.MediaIsSubtitled.Name,                AsfTags.MediaIsSubtitled                },
			{ AsfTags.MediaIsTape.Name,                     AsfTags.MediaIsTape                     },
			{ AsfTags.MediaNetworkAffiliation.Name,         AsfTags.MediaNetworkAffiliation         },
			{ AsfTags.MediaOriginalBroadcastDateTime.Name,  AsfTags.MediaOriginalBroadcastDateTime  },
			{ AsfTags.MediaOriginalChannel.Name,            AsfTags.MediaOriginalChannel            },
			{ AsfTags.MediaStationCallSign.Name,            AsfTags.MediaStationCallSign            },
			{ AsfTags.MediaStationName.Name,                AsfTags.MediaStationName                },
			{ AsfTags.ModifiedBy.Name,                      AsfTags.ModifiedBy                      },
			{ AsfTags.Mood.Name,                            AsfTags.Mood                            },
			{ AsfTags.OriginalAlbumTitle.Name,              AsfTags.OriginalAlbumTitle              },
			{ AsfTags.OriginalArtist.Name,                  AsfTags.OriginalArtist                  },
			{ AsfTags.OriginalFilename.Name,                AsfTags.OriginalFilename                },
			{ AsfTags.OriginalLyricist.Name,                AsfTags.OriginalLyricist                },
			{ AsfTags.OriginalReleaseTime.Name,             AsfTags.OriginalReleaseTime             },
			{ AsfTags.OriginalReleaseYear.Name,             AsfTags.OriginalReleaseYear             },
			{ AsfTags.ParentalRating.Name,                  AsfTags.ParentalRating                  },
			{ AsfTags.ParentalRatingReason.Name,            AsfTags.ParentalRatingReason            },
			{ AsfTags.PartOfSet.Name,                       AsfTags.PartOfSet                       },
			{ AsfTags.PeakBitrate.Name,                     AsfTags.PeakBitrate                     },
			{ AsfTags.Period.Name,                          AsfTags.Period                          },
			{ AsfTags.Picture.Name,                         AsfTags.Picture                         },
			{ AsfTags.PlaylistDelay.Name,                   AsfTags.PlaylistDelay                   },
			{ AsfTags.Producer.Name,                        AsfTags.Producer                        },
			{ AsfTags.PromotionUrl.Name,                    AsfTags.PromotionUrl                    },
			{ AsfTags.ProtectionType.Name,                  AsfTags.ProtectionType                  },
			{ AsfTags.Provider.Name,                        AsfTags.Provider                        },
			{ AsfTags.ProviderCopyright.Name,               AsfTags.ProviderCopyright               },
			{ AsfTags.ProviderRating.Name,                  AsfTags.ProviderRating                  },
			{ AsfTags.ProviderStyle.Name,                   AsfTags.ProviderStyle                   },
			{ AsfTags.Publisher.Name,                       AsfTags.Publisher                       },
			{ AsfTags.RadioStationName.Name,                AsfTags.RadioStationName                },
			{ AsfTags.RadioStationOwner.Name,               AsfTags.RadioStationOwner               },
			{ AsfTags.SharedUserRating.Name,                AsfTags.SharedUserRating                },
			{ AsfTags.StreamTypeInfo.Name,                  AsfTags.StreamTypeInfo                  },
			{ AsfTags.SubscriptionContentId.Name,           AsfTags.SubscriptionContentId           },
			{ AsfTags.SubTitle.Name,                        AsfTags.SubTitle                        },
			{ AsfTags.SubTitleDescription.Name,             AsfTags.SubTitleDescription             },
			{ AsfTags.Text.Name,                            AsfTags.Text                            },
			{ AsfTags.ToolName.Name,                        AsfTags.ToolName                        },
			{ AsfTags.ToolVersion.Name,                     AsfTags.ToolVersion                     },
			{ AsfTags.Track.Name,                           AsfTags.Track                           },
			{ AsfTags.TrackNumber.Name,                     AsfTags.TrackNumber                     },
			{ AsfTags.UniqueFileIdentifier.Name,            AsfTags.UniqueFileIdentifier            },
			{ AsfTags.UserWebUrl.Name,                      AsfTags.UserWebUrl                      },
			{ AsfTags.VideoClosedCaptioning.Name,           AsfTags.VideoClosedCaptioning           },
			{ AsfTags.VideoFrameRate.Name,                  AsfTags.VideoFrameRate                  },
			{ AsfTags.VideoHeight.Name,                     AsfTags.VideoHeight                     },
			{ AsfTags.VideoWidth.Name,                      AsfTags.VideoWidth                      },
			{ AsfTags.WmaDrcAverageReference.Name,          AsfTags.WmaDrcAverageReference          },
			{ AsfTags.WmaDrcAverageTarget.Name,             AsfTags.WmaDrcAverageTarget             },
			{ AsfTags.WmaDrcPeakReference.Name,             AsfTags.WmaDrcPeakReference             },
			{ AsfTags.WmaDrcPeakTarget.Name,                AsfTags.WmaDrcPeakTarget                },
			{ AsfTags.WmCollectionGroupId.Name,             AsfTags.WmCollectionGroupId             },
			{ AsfTags.WmCollectionId.Name,                  AsfTags.WmCollectionId                  },
			{ AsfTags.WmContentId.Name,                     AsfTags.WmContentId                     },
			{ AsfTags.WmShadowFileSourceDrmType.Name,       AsfTags.WmShadowFileSourceDrmType       },
			{ AsfTags.WmShadowFileSourceFileType.Name,      AsfTags.WmShadowFileSourceFileType      },
			{ AsfTags.Writer.Name,                          AsfTags.Writer                          },
			{ AsfTags.Year.Name,                            AsfTags.Year                            }
		};
	}
}
