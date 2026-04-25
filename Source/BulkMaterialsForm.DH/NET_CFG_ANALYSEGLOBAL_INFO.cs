// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ANALYSEGLOBAL_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ANALYSEGLOBAL_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSceneType;

	public double CameraHeight;

	public double CameraDistance;

	public NET_CFG_POLYGON stuNearDetectPoint;

	public NET_CFG_POLYGON stuFarDectectPoint;

	public int nNearDistance;

	public int nFarDistance;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSubType;

	public int nLaneNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_LANE[] stuLanes;

	public int nPlateHintNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szPlateHints;

	public int nLightGroupNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_LIGHTGROUPS[] stLightGroups;

	public bool bHangingWordPlate;

	public bool bNonStdPolicePlate;

	public bool bYellowPlateLetter;

	public int nReportMode;

	public int nPlateMatch;

	public int nJudgment;

	public int nLeftDivisionPtCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stLeftDivisionLine;

	public int nRightDivisionPtCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYLINE[] stRightDivisionLine;

	public NET_CFG_ADJUST_LIGHT_COLOR stAdjustLightColor;

	public int nParkingSpaceNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public NET_CFG_PARKING_SPACE[] stParkingSpaces;

	public int nStaffNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_STAFF[] stuStaffs;

	public uint nCalibrateAreaNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_CALIBRATEAREA_INFO[] stuCalibrateArea;

	public bool bFaceRecognition;

	public NET_CFG_FACERECOGNITION_SCENCE_INFO stuFaceRecognitionScene;

	public byte abJitter;

	public byte abDejitter;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved;

	public int nJitter;

	public bool bDejitter;

	public bool abCompatibleMode;

	public int nCompatibleMode;

	public int nCustomDataLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byCustomData;

	public double CameraAngle;

	public NET_CFG_POLYGON stuLandLineStart;

	public NET_CFG_POLYGON stuLandLineEnd;

	public bool bFaceDetection;

	public NET_CFG_FACEDETECTION_SCENCE_INFO stuFaceDetectionScene;

	public NET_CFG_TIME_PERIOD stuDayTimePeriod;

	public NET_CFG_TIME_PERIOD stuNightTimePeriod;

	public NET_CFG_TIME_PERIOD_SCENE_INFO stuTimePeriodSceneInfo;

	public NET_CFG_CALIBRATEAREA_SCENE_INFO stuCalibrateAreaSceneInfo;

	public EM_CFG_TIMEPERIOD_SWITCH_MODE emSwitchMode;

	public int nSceneNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_CFG_ANALYSEGLOBAL_SCENE[] stuMultiScene;

	public int nSceneCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSceneTypeList;

	public EM_DEPTH_TYPE emDepthType;

	public int nPtzPresetId;

	public uint unLongitude;

	public uint unLatitude;

	public bool bSceneTypeListEx;

	public int nSceneCountEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
	public string szSceneTypeListEx;

	public NET_CFG_ANATOMYTEMP_SCENCE_INFO stuAnatomyTempScene;

	public IntPtr pstuDetectRegionsInfo;

	public int nMaxDetectRegions;

	public int nDetectRegionsNum;

	public NET_CFG_DETAIL_DRIVEASSISTANT_INFO stuDriveAssistant;

	public bool bParkingSpaceChangeEnable;

	public EM_SCENE_TYPE emSceneType;

	public int nSceneCountEm;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_SCENE_TYPE[] emSceneTypeList;

	public NET_A_CFG_PARKING_STATISTICS_INFO stuParkingStatistics;
}
