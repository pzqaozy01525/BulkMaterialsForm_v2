// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VA_OBJECT_NONMOTOR

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VA_OBJECT_NONMOTOR
{
	public int nObjectID;

	public EM_CATEGORY_NONMOTOR_TYPE emCategory;

	public NET_RECT stuBoundingBox;

	public NET_RECT stuOriginalBoundingBox;

	public NET_COLOR_RGBA stuMainColor;

	public EM_OBJECT_COLOR_TYPE emColor;

	public bool bHasImage;

	public NET_NONMOTOR_PIC_INFO stuImage;

	public int nNumOfCycling;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_RIDER_INFO[] stuRiderList;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	public NET_FACE_SCENE_IMAGE stuFaceSceneImage;

	public int nNumOfFace;

	public float fSpeed;

	public NET_NONMOTOR_FEATURE_VECTOR_INFO stuNonMotorFeatureVectorInfo;

	public EM_FEATURE_VERSION emNonMotorFeatureVersion;

	public NET_NONMOTOR_PLATE_INFO stuNomotorPlateInfo;

	public NET_POINT stuObjCenter;

	public NET_FACE_FEATURE_VECTOR_INFO stuFaceFeatureVectorInfo;

	public EM_FEATURE_VERSION emFaceFeatureVersion;

	public int nCategoryConf;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szNonMotorFeatureVersion;

	public EM_OBJECT_NONMOTORANGLE_TYPE emNonMotorAngle;

	public EM_OBJECT_BASKET_TYPE emBasket;

	public EM_OBJECT_STORAGEBOX_TYPE emStorageBox;

	public uint nCompleteScore;

	public uint nClarityScore;

	public uint nStartSequence;

	public uint nEndSequence;

	public bool bIsErrorDetect;

	public uint nImageLightType;

	public uint nAbsScore;

	public EM_RAIN_SHED_TYPE emRainShedType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 22)]
	public string szSerialUUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
	public string szReserved;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2924)]
	public byte[] byReserved;
}
