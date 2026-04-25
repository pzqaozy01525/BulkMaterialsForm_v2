// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFICTRUCKFORBID_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFICTRUCKFORBID_INFO
{
	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nGroupID;

	public int nCountInGroup;

	public int nIndexInGroup;

	public double PTS;

	public NET_TIME_EX UTC;

	public int UTCMS;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public int nLane;

	public int nSequence;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public NET_EVENT_COMM_INFO stCommInfo;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	public byte[] byReserved;
}
