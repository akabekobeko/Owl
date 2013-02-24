
namespace Owl.Asf
{
	/// <summary>
	/// ASF の Header Object に格納される、子オブジェクト種別を定義します。
	/// </summary>
	enum HeaderObjectType
	{
		/// <summary>
		/// 未知の種別。
		/// </summary>
		Unknown,

		/// <summary>
		/// Content Description Object。
		/// </summary>
		ContentDescription,

		/// <summary>
		/// Extended Content Description Object。
		/// </summary>
		ExtendedContentDescription,

		/// <summary>
		/// File Properties Object。
		/// </summary>
		FileProperties
	}
}
