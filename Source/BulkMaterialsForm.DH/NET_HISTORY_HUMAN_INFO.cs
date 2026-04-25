// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HISTORY_HUMAN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HISTORY_HUMAN_INFO
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

	public EM_HAS_BACK_BAG emHasBackBag;

	public EM_HAS_CARRIER_BAG emHasCarrierBag;

	public EM_HAS_SHOULDER_BAG emHasShoulderBag;

	public EM_HAS_MESSENGER_BAG emMessengerBag;

	public NET_HISTORY_HUMAN_IMAGE_INFO stuImageInfo;

	public NET_HISTORY_HUMAN_IMAGE_INFO stuFaceImageInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
