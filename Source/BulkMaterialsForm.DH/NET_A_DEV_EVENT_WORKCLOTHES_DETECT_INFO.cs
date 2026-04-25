// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_WORKCLOTHES_DETECT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_WORKCLOTHES_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public EM_CLASS_TYPE emClassType;

	public uint nRuleID;

	public uint nObjectID;

	public uint nGroupID;

	public uint nCountInGroup;

	public uint nIndexInGroup;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	public NET_HUMAN_IMAGE_INFO stuHumanImage;

	public NET_HELMET_ATTRIBUTE stuHelmetAttribute;

	public NET_WORKCLOTHES_ATTRIBUTE stuWorkClothesAttribute;

	public NET_WORKPANTS_ATTRIBUTE stuWorkPantsAttribute;

	public int nAlarmType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSourceID;

	public EM_EVENT_WORKCLOTHES_RULE_TYPE emRuleType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	public NET_NORMALHAT_ATTRIBUTE stuNormalHat;

	public NET_MASK_ATTRIBUTE stuMask;

	public NET_APRON_ATTRIBUTE stuApron;

	public NET_GLOVE_ATTRIBUTE stuGlove;

	public NET_BOOT_ATTRIBUTE stuBoot;

	public NET_SHOESCOVER_ATTRIBUTE stuShoesCover;

	public NET_NOHAT_ATTRIBUTE stuNoHat;

	public NET_PROHELMET_ATTRIBUTE stuProhelmet;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	public NET_FIREPROOF_CLOTHES stuFireProofClothes;

	public IntPtr pstObjectInfo;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 688)]
	public sbyte[] byReserved;
}
