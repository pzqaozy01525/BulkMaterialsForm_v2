// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFICSNAPSHOT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFICSNAPSHOT_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szDeviceAddress;

	public uint nVideoTitleMask;

	public int nRedLightMargin;

	public float fLongVehicleLengthLevel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public float[] arfLargeVehicleLengthLevel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public float[] arfMediumVehicleLengthLevel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public float[] arfSmallVehicleLengthLevel;

	public float fMotoVehicleLengthLevel;

	public NET_BREAKINGSNAPTIMES_INFO stBreakingSnapTimes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public NET_DETECTOR_INFO[] arstDetector;

	public int nCarType;

	public int nMaxSpeed;

	public int nFrameMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] arnAdaptiveSpeed;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	public bool abSchemeRange;

	public uint nVideoTitleMask1;

	public uint nMergeVideoTitleMask;

	public uint nMergeVideoTitleMask1;

	public int nTriggerSource;

	public int nSnapMode;

	public int nWorkMode;

	public int nCarThreShold;

	public int nSnapType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public int[] nCustomFrameInterval;

	public int nKeepAlive;

	public NET_OSD_INFO stOSD;

	public NET_OSD_INFO stMergeOSD;

	public NET_CFG_NET_TIME stValidUntilTime;

	public NET_RADAR_INFO stRadar;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRoadwayCode;

	public uint nVideoTitleMask2;

	public uint nMergeVideoTitleMask2;

	public int nParkType;

	public uint nCoilSpeedAdjustDelayFrameTime;

	public bool bCoilSpeedAdjustEnable;

	public uint nSnapSigMinConfidence;

	public EM_MIX_SNAP_SPEED_SOURCE emMixSnapSpeedSource;
}
