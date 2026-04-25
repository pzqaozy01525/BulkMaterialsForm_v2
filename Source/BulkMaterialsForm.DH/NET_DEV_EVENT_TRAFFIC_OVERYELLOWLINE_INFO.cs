// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_OVERYELLOWLINE_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public int nLane;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public int nSpeed;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public int bIsExistAlarmRecord;

	public uint dwAlarmRecordSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szAlarmRecordPath;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 532)]
	public byte[] bReserved;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public int nDetectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	public NET_EVENT_COMM_INFO stCommInfo;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
