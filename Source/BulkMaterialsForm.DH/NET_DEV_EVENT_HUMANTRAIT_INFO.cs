// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_HUMANTRAIT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_HUMANTRAIT_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nEventID;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nAction;

	public EM_CLASS_TYPE emClassType;

	public int nGroupID;

	public int nCountInGroup;

	public int nIndexInGroup;

	public NET_HUMAN_IMAGE_INFO stuHumanImage;

	public NET_FACE_IMAGE_INFO stuFaceImage;

	public EM_DETECT_OBJECT emDetectObject;

	public NET_HUMAN_ATTRIBUTES_INFO stuHumanAttributes;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	public NET_FACE_ATTRIBUTE stuFaceAttributes;

	public NET_FACE_SCENE_IMAGE stuFaceSceneImage;

	public NET_EXTENSION_INFO stuExtensionInfo;

	public NET_HUMANTRAIT_EXTENSION_INFO stuHumanTrait;

	public NET_HUMAN_FEATURE_VECTOR_INFO stuHumanFeatureVectorInfo;

	public EM_FEATURE_VERSION emHumanFeatureVersion;

	public NET_FACE_FEATURE_VECTOR_INFO stuFaceFeatureVectorInfo;

	public EM_FEATURE_VERSION emFaceFeatureVersion;

	public uint nCompliantMark;

	public int nCompliantDetailsNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_COMPLIANTDETAIL_TYPE[] emCompliantDetailType;

	public int nHumanPostureTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_HUMAN_POSTURE_TYPE[] emHumanPostureType;

	public NET_HUMAN_IMAGE_INFO stuAlongWithFaceHumanImage;

	public NET_SCENE_IMAGE_INFO stuAlongWithFaceHumanSceneImage;

	public NET_HUMAN_ATTRIBUTES_INFO stuAlongWithFaceHumanAttributes;

	public bool bCompliantMarkEnable;

	public NET_HUMAN_FEATURE_VECTOR_INFO stuAlongWithFaceHumanVectorInfo;

	public EM_FEATURE_VERSION emAlongWithFaceHumanVersion;

	public uint nCompliantMode;

	public uint nAlarmCompliance;

	public uint nStartSequence;

	public uint nEndSequence;

	public EM_IMAGE_LIGHT_TYPE emImageLightType;

	public NET_A_HUMAN_ATTRIBUTES_INFO_EX stuHumanAttributesEx;

	public NET_A_HUMAN_ATTRIBUTES_INFO_EX stuAlongWithFaceHumanAttributesEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szObjectUUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szHumanFeatureVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szFaceFeatureVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szAlongWithFaceHumanVersion;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 880)]
	public string byReserved;
}
