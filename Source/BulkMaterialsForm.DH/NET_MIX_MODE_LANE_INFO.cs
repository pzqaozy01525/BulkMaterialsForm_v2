// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MIX_MODE_LANE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MIX_MODE_LANE_INFO
{
	public int nLaneNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_TRAFFIC_EVENT_CHECK_INFO[] stCheckInfo;
}
