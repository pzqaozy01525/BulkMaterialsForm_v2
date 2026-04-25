// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_FACERECOGNITION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_FACERECOGNITION_INFO
{
	public uint dwSize;

	public int bGlobalScenePic;

	public NET_PIC_INFO_EX stGlobalScenePic;

	public NET_MSG_OBJECT stuObject;

	public NET_PIC_INFO_EX stObjectPic;

	public int nCandidateNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CANDIDATE_INFO[] stuCandidates;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CANDIDAT_PIC_PATHS[] stuCandidatesPic;

	public NET_TIME stTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szAddress;

	public int nChannelId;

	public bool bUseCandidatesEx;

	public int nCandidateExNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CANDIDATE_INFOEX[] stuCandidatesEx;

	public NET_FACE_INFO_OBJECT stuFaceInfoObject;

	public NET_POINT stuFaceCenter;

	public NET_MEDIAFILE_GENERAL_INFO stuGeneralInfo;

	public int nRecNo;

	public bool bRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;
}
