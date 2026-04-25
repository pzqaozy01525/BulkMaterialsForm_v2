// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_TRAFFICJUNCTION_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_TRAFFICJUNCTION_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public byte byMainSeatBelt;

	public byte bySlaveSeatBelt;

	public byte byVehicleDirection;

	public byte byOpenStrobeState;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public int nLane;

	public uint dwBreakingRule;

	public NET_TIME_EX RedLightUTC;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nSequence;

	public int nSpeed;

	public byte bEventAction;

	public byte byDirection;

	public byte byLightState;

	public byte byReserved;

	public byte byImageIndex;

	public NET_MSG_OBJECT stuVehicle;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRecordFile;

	public NET_EVENT_JUNCTION_CUSTOM_INFO stuCustomInfo;

	public byte byPlateTextSource;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved1;

	public NET_GPS_INFO stuGPSInfo;

	public byte byNoneMotorInfo;

	public byte byBag;

	public byte byUmbrella;

	public byte byCarrierBag;

	public byte byHat;

	public byte byHelmet;

	public byte bySex;

	public byte byAge;

	public NET_COLOR_RGBA stuUpperBodyColor;

	public NET_COLOR_RGBA stuLowerBodyColor;

	public byte byUpClothes;

	public byte byDownClothes;

	public NET_EXTENSION_INFO stuExtensionInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 22)]
	public byte[] bReserved;

	public int nTriggerType;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	public uint dwRetCardNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_EVENT_CARD_INFO[] stuCardInfo;

	public NET_EVENT_COMM_INFO stCommInfo;

	public bool bNonMotorInfoEx;

	public NET_VA_OBJECT_NONMOTOR stuNonMotor;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public NET_EVENT_PLATE_INFO stuPlateInfo;

	public bool bSceneImage;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public IntPtr pstObjects;

	public int nObjectNum;

	public EM_VEHICLE_POSTURE_TYPE emVehiclePosture;

	public uint nVehicleSignConfidence;

	public uint nVehicleCategoryConfidence;

	public EM_CAR_DRIVING_DIRECTION emCarDrivingDirection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSerialNo;

	public uint nAlarmCompliance;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	public NET_A_MSG_OBJECT_SUPPLEMENT stObjectInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 588)]
	public string byReserved2;
}
