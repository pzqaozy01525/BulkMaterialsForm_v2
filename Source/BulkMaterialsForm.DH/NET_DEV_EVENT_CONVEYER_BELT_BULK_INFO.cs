// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CONVEYER_BELT_BULK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CONVEYER_BELT_BULK_INFO
{
	public int nChannelID;

	public int nEventAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double dPTS;

	public NET_TIME_EX UTC;

	public uint nRuleID;

	public EM_CLASS_TYPE emClassType;

	public int nDetectLineNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectLine;

	public uint nEventID;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public uint nSizeFilterThreshold;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_MSG_OBJECT[] stuObjects;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserver;
}
