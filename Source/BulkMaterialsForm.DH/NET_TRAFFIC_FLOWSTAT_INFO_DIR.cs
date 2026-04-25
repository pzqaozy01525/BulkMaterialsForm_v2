// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_FLOWSTAT_INFO_DIR

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_FLOWSTAT_INFO_DIR
{
	public EM_NET_FLOWSTAT_DIRECTION emDrivingDir;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szUpGoing;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDownGoing;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] reserved;
}
