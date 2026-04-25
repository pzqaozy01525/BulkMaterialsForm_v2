// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACERECOGNITION_PERSON_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACERECOGNITION_PERSON_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPersonName;

	public ushort wYear;

	public byte byMonth;

	public byte byDay;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szID;

	public byte bImportantRank;

	public byte bySex;

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

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPersonNameEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
	public string szCountry;

	public byte byIsCustomType;

	public IntPtr pszComment;

	public IntPtr pszGroupID;

	public IntPtr pszGroupName;

	public IntPtr pszFeatureValue;

	public byte bGroupIdLen;

	public byte bGroupNameLen;

	public byte bFeatureValueLen;

	public byte bCommentLen;

	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE emEmotion;
}
