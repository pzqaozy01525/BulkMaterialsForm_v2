// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_HIGH_TOSS_DETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_HIGH_TOSS_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public uint nRuleID;

	public EM_CLASS_TYPE emClassType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_HIGHTOSS_OBJECT_INFO[] stuObjInfos;

	public uint nObjNum;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public int nFrameSequence;

	public int nGroupID;

	public int nIndexInGroup;

	public int nCountInGroup;

	public NET_EVENT_IMAGE_OFFSET_INFO stuImageInfo;

	public bool bIsGlobalScene;

	public int nMark;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 384)]
	public byte[] byReserved;
}
