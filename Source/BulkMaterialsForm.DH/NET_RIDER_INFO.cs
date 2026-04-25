// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RIDER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RIDER_INFO
{
	public bool bFeatureValid;

	public EM_SEX_TYPE emSex;

	public int nAge;

	public EM_NONMOTOR_OBJECT_STATUS emHelmet;

	public EM_NONMOTOR_OBJECT_STATUS emCall;

	public EM_NONMOTOR_OBJECT_STATUS emBag;

	public EM_NONMOTOR_OBJECT_STATUS emCarrierBag;

	public EM_NONMOTOR_OBJECT_STATUS emUmbrella;

	public EM_NONMOTOR_OBJECT_STATUS emGlasses;

	public EM_NONMOTOR_OBJECT_STATUS emMask;

	public EM_EMOTION_TYPE emEmotion;

	public EM_CLOTHES_TYPE emUpClothes;

	public EM_CLOTHES_TYPE emDownClothes;

	public EM_OBJECT_COLOR_TYPE emUpperBodyColor;

	public EM_OBJECT_COLOR_TYPE emLowerBodyColor;

	public bool bHasFaceImage;

	public NET_RIDER_FACE_IMAGE_INFO stuFaceImage;

	public bool bHasFaceAttributes;

	public NET_FACE_ATTRIBUTE_EX stuFaceAttributes;

	public EM_HAS_HAT emHasHat;

	public EM_CAP_TYPE emCap;

	public EM_HAIR_STYLE emHairStyle;

	public NET_FACE_FEATURE_VECTOR_INFO stuFaceFeatureVectorInfo;

	public EM_FEATURE_VERSION emFaceFeatureVersion;

	public NET_HUMAN_FEATURE_VECTOR_INFO stuHumanFeatureVectorInfo;

	public EM_FEATURE_VERSION emHumanFeatureVersion;

	public uint nAgeConf;

	public uint nUpColorConf;

	public uint nDownColorConf;

	public uint nUpTypeConf;

	public uint nDownTypeConf;

	public uint nHatTypeConf;

	public uint nHairTypeConf;

	public EM_CLOTHES_PATTERN emUpperPattern;

	public uint nUpClothes;

	public EM_UNIFORM_STYLE emUniformStyle;

	public uint nRainCoat;

	public EM_COAT_TYPE emCoatStyle;

	public EM_AGE_SEG emAgeSeg;

	public uint nShoulderBag;

	public uint nMessengerBag;

	public bool bNewUpClothes;

	public EM_NEWUPCLOTHES_TYPE emNewUpClothes;

	public bool bNewDownClothes;

	public EM_NEWDOWNCLOTHES_TYPE emNewDownClothes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 140)]
	public byte[] byReserved;
}
