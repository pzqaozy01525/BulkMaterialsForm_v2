// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RELATING_VIDEO_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RELATING_VIDEO_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szVideoPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szReserved;
}
