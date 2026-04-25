// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_SMART_KITCHEN_CLOTHES_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_SMART_KITCHEN_CLOTHES_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public uint nRuleID;

	public EM_CLASS_TYPE emClassType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szClassAlias;

	public NET_HUMAN_IMAGE_INFO stuHumanImage;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	public NET_FACE_IMAGE_INFO stuFaceImage;

	public uint nObjectID;

	public EM_NONMOTOR_OBJECT_STATUS emHasMask;

	public EM_NONMOTOR_OBJECT_STATUS emHasChefHat;

	public EM_NONMOTOR_OBJECT_STATUS emHasChefClothes;

	public EM_OBJECT_COLOR_TYPE emChefClothesColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
