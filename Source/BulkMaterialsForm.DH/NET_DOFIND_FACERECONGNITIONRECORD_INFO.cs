// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DOFIND_FACERECONGNITIONRECORD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DOFIND_FACERECONGNITIONRECORD_INFO
{
	public bool bGlobalScenePic;

	public NET_PIC_INFO_CPP stGlobalScenePic;

	public NET_MSG_OBJECT stuObject;

	public NET_PIC_INFO_CPP stObjectPic;

	public int nCandidateNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CANDIDATE_INFO[] stuCandidates;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CANDIDAT_PIC_PATHS_EX[] stuCandidatesPic;

	public NET_TIME stTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szAddress;

	public int nChannelId;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] bReserved;
}
