// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_TRAFFIC_VEHICLE_CLEANLINESS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_TRAFFIC_VEHICLE_CLEANLINESS_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public uint nRuleId;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public EM_TRIGGER_TYPE emTriggerType;

	public NET_EVENT_COMM_INFO stuCommInfo;

	public int nCleanValue;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
