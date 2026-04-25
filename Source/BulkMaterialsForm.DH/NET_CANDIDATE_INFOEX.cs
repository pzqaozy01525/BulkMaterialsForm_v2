// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CANDIDATE_INFOEX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CANDIDATE_INFOEX
{
	public NET_FACERECOGNITION_PERSON_INFOEX stPersonInfo;

	public byte bySimilarity;

	public byte byRange;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved1;

	public NET_TIME stTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szAddress;

	public bool bIsHit;

	public NET_PIC_INFO_EX3 stuSceneImage;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szFilePathEx;

	public NET_HISTORY_HUMAN_INFO stuHistoryHumanInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 136)]
	public byte[] byReserved;
}
