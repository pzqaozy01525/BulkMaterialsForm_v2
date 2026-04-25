// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AV_CFG_MonitorWallTVOut

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AV_CFG_MonitorWallTVOut
{
	public int nStructSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDeviceID;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public bool bIsVirtual;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szAddress;

	public NET_AV_CFG_MONITOR_WALL_OUT_MODE_INFO stuOutMode;
}
