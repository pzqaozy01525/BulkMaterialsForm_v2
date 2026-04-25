// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleColor;

	public int nSpeed;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szEvent;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szViolationCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szViolationDesc;

	public int nLowerSpeedLimit;

	public int nUpperSpeedLimit;

	public int nOverSpeedMargin;

	public int nUnderSpeedMargin;

	public int nLane;

	public int nVehicleSize;

	public float fVehicleLength;

	public int nSnapshotMode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szChannelName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMachineName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMachineGroup;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRoadwayNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 768)]
	public string szDrivingDirection;

	public IntPtr szDeviceAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleSign;

	public NET_SIG_CARWAY_INFO_EX stuSigInfo;

	public IntPtr szMachineAddr;

	public float fActualShutter;

	public byte byActualGain;

	public byte byDirection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public IntPtr szDetailedAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDefendCode;

	public int nTrafficBlackListID;

	public NET_COLOR_RGBA stuRGBA;

	public NET_TIME stSnapTime;

	public int nRecNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
	public string szCustomParkNo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved1;

	public int nDeckNo;

	public int nFreeDeckCount;

	public int nFullDeckCount;

	public int nTotalDeckCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szViolationName;

	public uint nWeight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCustomRoadwayDirection;

	public byte byPhysicalLane;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved2;

	public EM_TRAFFICCAR_MOVE_DIRECTION emMovingDirection;

	public NET_TIME stuEleTagInfoUTC;

	public NET_RECT stuCarWindowBoundingBox;

	public NET_TRAFFICCAR_WHITE_LIST stuWhiteList;

	public EM_TRAFFICCAR_CAR_TYPE emCarType;

	public EM_TRAFFICCAR_LANE_TYPE emLaneType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szVehicleBrandYearText;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCategory;

	public NET_TRAFFICCAR_BLACK_LIST stuBlackList;

	public EM_VEHICLE_DIRECTION emFlowDirection;

	public EM_TOLLS_VEHICLE_TYPE emTollsVehicleType;

	public uint nAxleType;

	public uint nAxleCount;

	public uint nWheelNum;

	public NET_TRAFFICCAR_ORIGINAL_VEHICLE stuOriginalVehicle;

	public EM_VEHICLE_TYPE_BY_FUNC emVehicleTypeByFunc;

	public ushort nSunBrand;

	public ushort nBrandYear;

	public int nTrafficLightType;

	public EM_PLATE_ATTRIBUTE emPlateAttribute;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
	public byte[] bReserved;
}
