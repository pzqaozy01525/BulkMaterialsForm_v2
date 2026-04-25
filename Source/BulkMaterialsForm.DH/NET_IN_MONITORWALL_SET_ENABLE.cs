// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_MONITORWALL_SET_ENABLE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_MONITORWALL_SET_ENABLE
{
	public uint dwSize;

	public int nMonitorWallNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_MONITORWALL_ENABLE_INFO[] stuEnable;
}
