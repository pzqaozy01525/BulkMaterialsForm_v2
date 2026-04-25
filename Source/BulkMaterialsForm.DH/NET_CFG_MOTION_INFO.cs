// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_MOTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_MOTION_INFO
{
	public int nChannelID;

	public bool bEnable;

	public int nSenseLevel;

	public int nMotionRow;

	public int nMotionCol;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byRegion;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;

	public int nVersion;

	public bool bSenseLevelEn;

	public bool bVRatioEn;

	public int nVolumeRatio;

	public bool bSRatioEn;

	public int nSubRatio;

	public bool abWindow;

	public int nWindowCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_MOTION_WINDOW[] stuWindows;

	public bool abDetectRegion;

	public int nRegionCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_DETECT_REGION[] stuRegion;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuRemoteEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
	public NET_CFG_TIME_SECTION[] stuRemoteTimeSection;
}
