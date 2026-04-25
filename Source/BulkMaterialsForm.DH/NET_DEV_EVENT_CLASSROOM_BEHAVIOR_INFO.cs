// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CLASSROOM_BEHAVIOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CLASSROOM_BEHAVIOR_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public EM_CLASS_TYPE emClassType;

	public uint nRuleID;

	public uint nObjectID;

	public uint nSequence;

	public EM_CLASSROOM_ACTION emClassroomAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public int nDetectRegionNum;

	public uint nPresetID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPresetName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 22)]
	public string szSerialUUID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved1;

	public NET_RECT stuBoundingBox;

	public NET_INTELLIGENCE_IMAGE_INFO stuSceneImage;

	public NET_INTELLIGENCE_IMAGE_INFO stuFaceImage;

	public NET_FACE_ATTRIBUTE_EX stuFaceAttributes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string byReserved;
}
