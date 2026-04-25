// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CONVEYORBLOCK_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CONVEYORBLOCK_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public EM_CLASS_TYPE emClassType;

	public uint nRuleID;

	public double dPTS;

	public NET_TIME_EX UTC;

	public uint nUTCMS;

	public uint nEventID;

	public uint nSequence;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	public bool bSceneImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string byReserved;
}
