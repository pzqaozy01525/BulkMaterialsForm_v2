// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESSCTL_SPECIALDAY_GROUP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESSCTL_SPECIALDAY_GROUP_INFO
{
	public uint dwSize;

	public bool bGroupEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szGroupName;

	public int nSpeciaday;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_ACCESSCTL_SPECIALDAY_INFO[] stuSpeciaday;
}
