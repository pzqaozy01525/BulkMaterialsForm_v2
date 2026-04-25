// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_WITHOUT_SAFEBELT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_WITHOUT_SAFEBELT
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

	public int nTriggerType;

	public uint PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nSequence;

	public byte byEventAction;

	public byte byImageIndex;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved1;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nLane;

	public int nMark;

	public int nFrameSequence;

	public int nSource;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;

	public int nSpeed;

	public EM_SAFEBELT_STATE emMainSeat;

	public EM_SAFEBELT_STATE emSlaveSeat;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 728)]
	public byte[] byReserved;

	public NET_EVENT_COMM_INFO stCommInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szVideoPath;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
