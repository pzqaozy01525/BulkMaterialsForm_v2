// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_NONMOTOR_ENTRYING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_NONMOTOR_ENTRYING_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nRuleID;

	public int nSequence;

	public EM_CLASS_TYPE emClassType;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_VA_OBJECT_NONMOTOR[] stuObjects;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string byReserved;
}
