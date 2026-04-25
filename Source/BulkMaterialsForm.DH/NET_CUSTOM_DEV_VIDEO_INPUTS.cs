// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CUSTOM_DEV_VIDEO_INPUTS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CUSTOM_DEV_VIDEO_INPUTS
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMainStreamUrl;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szExtraStreamUrl;

	public EM_VIDEOINPUTS_SERVICE_TYPE emServiceType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
	public byte[] byReserved;
}
