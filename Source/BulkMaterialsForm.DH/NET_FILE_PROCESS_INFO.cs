// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FILE_PROCESS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FILE_PROCESS_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	public int nRelatingVideoInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_RELATING_VIDEO_INFO[] stuRelatingVideoInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
