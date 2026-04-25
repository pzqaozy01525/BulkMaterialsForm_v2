// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CANDIDATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CANDIDATE_INFO
{
	public NET_FACERECOGNITION_PERSON_INFO stPersonInfo;

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

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
