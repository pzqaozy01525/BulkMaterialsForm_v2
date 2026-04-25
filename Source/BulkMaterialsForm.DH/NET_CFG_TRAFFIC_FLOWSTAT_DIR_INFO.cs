// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFIC_FLOWSTAT_DIR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFIC_FLOWSTAT_DIR_INFO
{
	public NET_CFG_FLOWSTAT_DIRECTION emDrivingDir;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szUpGoing;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDownGoing;
}
