// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_PARKING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_PARKING_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

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
	public byte[] reserved;

	public byte byImageIndex;

	public NET_TIME_EX stuStartParkingTime;

	public int nSequence;

	public int nAlarmIntervalTime;

	public int nParkingAllowedTime;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public bool bIsExistAlarmRecord;

	public uint dwAlarmRecordSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szAlarmRecordPath;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szFTPPath;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public byte byPreAlarm;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved2;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 228)]
	public byte[] bReserved;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public NET_EVENT_COMM_INFO stCommInfo;

	public NET_VA_OBJECT_NONMOTOR stuNonMotor;

	public bool bHasNonMotor;

	public uint nParkingDuration;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
