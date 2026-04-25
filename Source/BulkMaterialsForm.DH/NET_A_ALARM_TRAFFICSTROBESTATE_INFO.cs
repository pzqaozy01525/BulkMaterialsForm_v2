// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_TRAFFICSTROBESTATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_TRAFFICSTROBESTATE_INFO
{
	public byte bEventAction;

	public NET_TIME stuTime;

	public int nChannelID;

	public EM_TRAFFICSTROBE_STATUS emStatus;

	public EM_TRAFFIC_SNAP_STROBE_ACTION_REASON_TYPE emStrobeActionReason;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
