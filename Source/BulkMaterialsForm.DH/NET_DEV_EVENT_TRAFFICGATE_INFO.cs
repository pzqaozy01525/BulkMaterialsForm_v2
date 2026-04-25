// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFICGATE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFICGATE_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public byte byOpenStrobeState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
	public string bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public int nLane;

	public int nSpeed;

	public int nSpeedUpperLimit;

	public int nSpeedLowerLimit;

	public uint dwBreakingRule;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_MSG_OBJECT stuVehicle;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szManualSnapNo;

	public int nSequence;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szSnapFlag;

	public byte bySnapMode;

	public byte byOverSpeedPercentage;

	public byte byUnderSpeedingPercentage;

	public byte byRedLightMargin;

	public byte byDriveDirection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRoadwayNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szViolationCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szViolationDesc;

	public NET_RESOLUTION_INFO stuResolution;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleType;

	public byte byVehicleLenth;

	public byte byLightState;

	public byte byReserved1;

	public byte byImageIndex;

	public int nOverSpeedMargin;

	public int nUnderSpeedMargin;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 768)]
	public string szDrivingDirection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMachineName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMachineAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMachineGroup;

	public uint dwSnapFlagMask;

	public NET_SIG_CARWAY_INFO_EX stuSigInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;

	public NET_TIME_EX RedLightUTC;

	public IntPtr szDeviceAddress;

	public float fActualShutter;

	public byte byActualGain;

	public byte byDirection;

	public byte bReserve;

	public byte bRetCardNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_EVENT_CARD_INFO[] stuCardInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDefendCode;

	public int nTrafficBlackListID;

	public NET_EVENT_COMM_INFO stCommInfo;

	public EM_VEHICLE_DIRECTION emVehicleDirection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 448)]
	public byte[] bReserved;
}
