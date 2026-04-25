// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_WIFI_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_WIFI_INFO
{
	public bool bSyncEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSSID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPassword;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
