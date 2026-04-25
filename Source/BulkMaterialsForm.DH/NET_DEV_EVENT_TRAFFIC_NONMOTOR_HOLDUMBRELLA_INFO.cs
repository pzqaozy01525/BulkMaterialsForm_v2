// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_NONMOTOR_HOLDUMBRELLA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_NONMOTOR_HOLDUMBRELLA_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_MSG_OBJECT stuObject;

	public NET_VA_OBJECT_NONMOTOR stuNonMotor;

	public int nLane;

	public int nSequence;

	public NET_EVENT_COMM_INFO stCommInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
	public byte[] byReserved;
}
