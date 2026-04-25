// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IMAGE_RELATION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IMAGE_RELATION
{
	public int nBigPicId;

	public int nSmallPicNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_SMALL_PIC_INFO[] stuSmallPicInfo;

	public EM_MULTIFACE_DETECT_ERRCODE emDetectErrCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] bReserved;
}
