// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CONVEYER_BELT_COAL_RATIO_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CONVEYER_BELT_COAL_RATIO_INFO
{
	public int nChannelID;

	public int nEventAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public EM_CLASS_TYPE emClassType;

	public uint nRuleID;

	public NET_TIME_EX UTC;

	public uint UTCMS;

	public uint nEventID;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_UINT_POINT[] stuDetectRegion;

	public float fCoalData;

	public uint nAlarmOutMode;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] szReserved;
}
