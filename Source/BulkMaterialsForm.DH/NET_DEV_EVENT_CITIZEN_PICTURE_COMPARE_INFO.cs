// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_CITIZEN_PICTURE_COMPARE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_CITIZEN_PICTURE_COMPARE_INFO
{
	public int nChannelID;

	public int nEventAction;

	public double dbPTS;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public NET_TIME_EX stuUTC;

	public int nEventID;

	[MarshalAs(UnmanagedType.I1)]
	public bool bCompareResult;

	public byte nSimilarity;

	public byte nThreshold;

	public EM_CITIZENIDCARD_SEX_TYPE emSex;

	public int nECType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCitizen;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAuthority;

	public NET_TIME stuBirth;

	public NET_TIME stuValidityStart;

	public bool bLongTimeValidFlag;

	public NET_TIME stuValidityEnd;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public CITIZEN_PICTURE_COMPARE_IMAGE_INFO[] stuImageInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szCellPhone;

	public NET_EXTENSION_INFO stuExtensionInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public CITIZEN_PICTURE_COMPARE_IMAGE_INFO_EX[] stuImageInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szCallNumber;

	public EM_A_NET_ACCESS_DOOROPEN_METHOD emDoorOpenMethod;

	public uint nEventGroupID;

	public uint nEventType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szBuildingNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szBuildingUnitNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szBuildingRoomNo;

	public uint nFaceIndex;

	public EM_MASK_STATE_TYPE emMask;

	public bool bManTemperature;

	public NET_MAN_TEMPERATURE_INFO stuManTemperatureInfo;

	public double dbBulkOilQuantity;

	public int nScore;

	public IntPtr pstuCardNoArray;

	public IntPtr pstuFingerPrint;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szIDPhysicalNumber;

	public EM_CARD_TYPE emCardType;

	public int nCardTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public EM_CARD_TYPE[] arrCardTypeArray;

	public uint nVisitorNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szTrafficPlate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRespondentsName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szStudentNum;
}
