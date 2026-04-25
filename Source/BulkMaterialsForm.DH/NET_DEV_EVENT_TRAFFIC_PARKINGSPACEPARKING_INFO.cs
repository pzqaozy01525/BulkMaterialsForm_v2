// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_PARKINGSPACEPARKING_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bReserved1;

	public uint PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nLane;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nSequence;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public int nParkingSpaceStatus;

	public NET_DEV_TRAFFIC_PARKING_INFO stTrafficParingInfo;

	public byte byPlateTextSource;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved2;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szParkingNum;

	public uint dwPresetNum;

	public bool bParkingFault;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 364)]
	public byte[] bReserved;

	public NET_EVENT_COMM_INFO stCommInfo;

	public NET_INTELLIGENCE_IMAGE_INFO stuParkingImage;

	public uint nConfidence;

	public EM_ACROSS_PARKING emAcrossParking;

	public EM_PARKINGSPACE_DIRECTION emParkingDirection;

	public EM_FORBID_PARKING_STATUS emForbidParkingStatus;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1004)]
	public byte[] byReserved1;

	public EM_PARKING_TRIGGER_TYPE emTriggerType;

	public NET_DEV_OCCUPIED_WARNING_INFO stuOccupiedWarningInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 384)]
	public string szAllParkingNo;

	public int nParkingNoNum;

	public EM_PARKING_SPACE_TYPE emParkingSpaceType;

	public NET_PARKING_CHANGE_INFO stuParkingChangeInfo;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved;
}
