// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_CHECK_CLOUD_UPGRADER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_CHECK_CLOUD_UPGRADER
{
	public uint dwSize;

	public EM_CLOUD_UPGRADER_CHECK_STATE emState;

	public EM_CLOUD_UPGRADER_PACKAGE_TYPE emPackageType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szOldVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNewVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szAttention;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPackageURL;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPackageID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCheckSum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBuildTime;
}
