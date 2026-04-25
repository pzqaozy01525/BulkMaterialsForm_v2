// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMAN_ATTRIBUTES_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMAN_ATTRIBUTES_INFO
{
	public EM_CLOTHES_COLOR emCoatColor;

	public EM_COAT_TYPE emCoatType;

	public EM_CLOTHES_COLOR emTrousersColor;

	public EM_TROUSERS_TYPE emTrousersType;

	public EM_HAS_HAT emHasHat;

	public EM_HAS_BAG emHasBag;

	public NET_RECT stuBoundingBox;

	public int nAge;

	public EM_SEX_TYPE emSex;

	public EM_ANGLE_TYPE emAngle;

	public EM_HAS_UMBRELLA emHasUmbrella;

	public EM_BAG_TYPE emBag;

	public EM_CLOTHES_PATTERN emUpperPattern;

	public EM_HAIR_STYLE emHairStyle;

	public EM_CAP_TYPE emCap;

	public NET_POINT stuHumanCenter;

	public EM_HAS_VEST emHasVest;

	public EM_HAS_BADGE emHasBadge;

	public EM_HAS_BABYCARRIAGE emHasBabyCarriage;

	public EM_IS_ERRORDETECT emIsErrorDetect;

	public EM_HAS_HEAD emHasHead;

	public EM_HAS_DOWNBODY emHasDownBody;

	public uint nAngleConf;

	public uint nUpColorConf;

	public uint nDownColorConf;

	public uint nGenderConf;

	public uint nAgeConf;

	public uint nHatTypeConf;

	public uint nUpTypeConf;

	public uint nDownTypeConf;

	public uint nHairTypeConf;

	public uint nHasHeadConf;

	public uint nHasDownBodyConf;

	public uint nUniformStyleConf;

	public sbyte nCoatType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved;
}
