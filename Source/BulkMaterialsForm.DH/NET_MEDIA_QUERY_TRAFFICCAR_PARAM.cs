// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIA_QUERY_TRAFFICCAR_PARAM

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIA_QUERY_TRAFFICCAR_PARAM
{
	public int nChannelID;

	public NET_TIME StartTime;

	public NET_TIME EndTime;

	public int nMediaType;

	public int nEventType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateNumber;

	public int nSpeedUpperLimit;

	public int nSpeedLowerLimit;

	public bool bSpeedLimit;

	public uint dwBreakingRule;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPlateColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szVehicleColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szVehicleSize;

	public int nGroupID;

	public short byLane;

	public byte byFileFlag;

	public byte byRandomAccess;

	public int nFileFlagEx;

	public int nDirection;

	public IntPtr szDirs;

	public IntPtr pEventTypes;

	public int nEventTypeNum;

	public IntPtr pszDeviceAddress;

	public IntPtr pszMachineAddress;

	public IntPtr pszVehicleSign;

	public ushort wVehicleSubBrand;

	public ushort wVehicleYearModel;

	public EM_SAFE_BELT_STATE emSafeBeltState;

	public EM_CALLING_STATE emCallingState;

	public EM_ATTACHMENT_TYPE emAttachMentType;

	public EM_CATEGORY_TYPE emCarType;

	public IntPtr pstuTrafficCarParamEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public int[] bReserved;
}
