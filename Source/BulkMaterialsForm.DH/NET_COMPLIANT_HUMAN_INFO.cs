// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COMPLIANT_HUMAN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COMPLIANT_HUMAN_INFO
{
	public NET_HUMAN_AGE_INFO stuHumanAge;

	public NET_HUMAN_SEX_INFO stuHumanSex;

	public NET_HUMAN_EMOTION_INFO stuHumanEmotion;

	public NET_HUMAN_GLASSES_INFO stuHumanGlasses;

	public NET_HUMAN_MASK_INFO stuHumanMask;

	public NET_HUMAN_BEARD_INFO stuHumanBeard;

	public NET_HUMAN_COAT_TYPE_INFO stuHumanCoatType;

	public NET_HUMAN_COAT_COLOR_INFO stuHumanCoatColor;

	public NET_HUMAN_TROUSERS_TYPE_INFO stuHumanTrousersType;

	public NET_HUMAN_TROUSERS_COLOR_INFO stuHumanTrousersColor;

	public NET_HUMAN_HAS_BAG_INFO stuHumanHasBag;

	public NET_HUMAN_HAS_UMBRELLA_INFO stuHumanHasUmbrella;

	public NET_HUMAN_RAIN_COAT_INFO stuHumanRainCoat;

	public NET_HUMAN_HAS_HAT_INFO stuHumanHasHat;

	public NET_HUMAN_HELMET_INFO stuHumanHelmet;

	public NET_HUMAN_VEST_INFO stuHumanVest;

	public NET_HUMAN_HAIR_STYLE_INFO stuHumanHairStyle;

	public NET_HUMAN_ANGLE_INFO stuHumanAngle;

	public NET_HUMAN_HOLD_BABY_INFO stuHumanHoldBaby;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
