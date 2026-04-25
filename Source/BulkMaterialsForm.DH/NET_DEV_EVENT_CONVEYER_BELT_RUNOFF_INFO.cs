// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CONVEYER_BELT_RUNOFF_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CONVEYER_BELT_RUNOFF_INFO
{
	public int nChannelID;

	public int nEventAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public uint nEventID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nRuleID;

	public EM_CLASS_TYPE emClassType;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public uint nWarningThreshold;

	public uint nDowntimeThreshold;

	public uint nAlarmType;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_MSG_OBJECT[] stuObjects;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserver;
}
