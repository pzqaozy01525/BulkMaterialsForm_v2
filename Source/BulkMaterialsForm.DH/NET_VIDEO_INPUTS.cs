// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VIDEO_INPUTS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VIDEO_INPUTS
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szChnName;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szControlID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szMainStreamUrl;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szExtraStreamUrl;

	public int nOptionalMainUrlCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2080)]
	public byte[] szOptionalMainUrls;

	public int nOptionalExtraUrlCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2080)]
	public byte[] szOptionalExtraUrls;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCaption;

	public EM_STREAM_TRANSMISSION_SERVICE_TYPE emServiceType;

	public NET_SOURCE_STREAM_ENCRYPT stuSourceStreamEncrypt;
}
