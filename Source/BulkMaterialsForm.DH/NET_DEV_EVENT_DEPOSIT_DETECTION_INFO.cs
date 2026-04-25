// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_DEPOSIT_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_DEPOSIT_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public uint nEventID;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRegionName;

	public uint nStackThreshold;

	public uint nGridState;

	public NET_INTELLIGENCE_IMAGE_INFO stuSceneImage;

	public NET_INTELLIGENCE_IMAGE_INFO stuDepositImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;

	public NET_CFG_MASK_INFO stuMask;

	public EM_DEPOSIT_DETECTION_SCENE_TYPE emSceneType;
}
