// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_ANIMAL_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_ANIMAL_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public uint nRuleID;

	public uint nSequence;

	public NET_ANIMAL_SCENE_IMAGE_INFO stuSceneImage;

	public NET_ANIMAL_OBJECTS_STATISTICS stuObjectsStatistics;

	public EM_CLASS_TYPE emClassType;

	public EM_DETECTION_SCENE_TYPE emDetectionSceneType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	public int nObjectListCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_ANIMAL_OBJECT_LIST_INFO[] stuObjectListInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string byReserved;
}
