// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_BREED_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_BREED_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public uint nRuleID;

	public uint nSequence;

	public EM_CLASS_TYPE emClassType;

	public NET_SCENE_IMAGE_INFO_EX stuSceneImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_VAOBJECT_ANIMAL_INFO[] stuObjects;

	public double dBreedStallTemp;

	public uint nBreedStallNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 500)]
	public byte[] byReserved;
}
