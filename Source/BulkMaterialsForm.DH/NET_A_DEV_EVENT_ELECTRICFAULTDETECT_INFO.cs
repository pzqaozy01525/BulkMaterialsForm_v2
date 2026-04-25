// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_ELECTRICFAULTDETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_ELECTRICFAULTDETECT_INFO
{
	public EM_CLASS_TYPE emClassType;

	public uint nChannel;

	public uint nRuleID;

	public int nEventID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nPresetID;

	public uint nUTCMS;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public EM_A_ELECTRIC_FAULT_ENABLE_RULES[] emEnableRules;

	public int nEnableRulesNum;

	public int nAirborneDetectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_AIRBORNE_DETECT[] stuAirborneDetectInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_NEST_DETECT[] stuNestDetectInfo;

	public int nNestDetectNum;

	public int nDialDetectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_DIAL_DETECT[] stuDialDetectInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_LEAKAGE_DETECT[] stuLeakageDetectInfo;

	public int nLeakageDetectNum;

	public int nDoorDetectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_DOOR_DETECT[] stuDoorDetectInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_RESPIRATOR_DETECT[] stuRespiratorDetectInfo;

	public int nRespiratorDetectNum;

	public int nSmokingDetectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_SMOKING_DETECT[] stuSmokingDetectInfo;

	public NET_SCENE_IMAGE_INFO stuSceneImageInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_INSULATOR_DETECT[] stuInsulatorDetectInfo;

	public int nInsulatorDetectNum;

	public int nCoverPlateDetectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_COVER_PLATE_DETECT[] stuCoverPlateDetectInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_PRESSING_PLATE_DETECT[] stuPressingPlateDetectInfo;

	public int nPressingPlateDetectNum;

	public int nMetalCorrosionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_METAL_CORROSION[] stuMetalCorrosionInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
