// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACERECOGNITION_PERSON_INFOEX

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACERECOGNITION_PERSON_INFOEX
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPersonName;

	public ushort wYear;

	public byte byMonth;

	public byte byDay;

	public byte bImportantRank;

	public byte bySex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szID;

	public ushort wFacePicNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public NET_PIC_INFO[] szFacePicInfo;

	public byte byType;

	public byte byIDType;

	public byte byGlasses;

	public byte byAge;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szProvince;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCity;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
	public string szCountry;

	public byte byIsCustomType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szCustomType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 100)]
	public string szComment;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szGroupName;

	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE emEmotion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szHomeAddress;

	public EM_GLASSES_TYPE emGlassesType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	public EM_EYE_STATE_TYPE emEye;

	public EM_MOUTH_STATE_TYPE emMouth;

	public EM_MASK_STATE_TYPE emMask;

	public EM_BEARD_STATE_TYPE emBeard;

	public int nAttractive;

	public EM_PERSON_FEATURE_STATE emFeatureState;

	public bool bAgeEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] nAgeRange;

	public int nEmotionValidNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emEmotions;

	public int nCustomPersonInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_CUSTOM_PERSON_INFO[] szCustomPersonInfo;

	public EM_REGISTER_DB_TYPE emRegisterDbType;

	public NET_TIME stuEffectiveTime;

	public EM_PERSON_FEATURE_ERRCODE emFeatureErrCode;

	public uint wFacePicNumEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public NET_FACE_PIC_INFO[] szFacePicInfoEx;

	public NET_PERSON_FEATURE_VALUE_INFO stuPersonFeatureValue;

	public bool bFrozenStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved;

	public NET_PERSON_FREQUENCY_INFO stuFrequencyInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUUID;

	public IntPtr pstuCustomPasserbyInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 184)]
	public byte[] byReserved;
}
