// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_DOFIND_FACERECONGNITION

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_DOFIND_FACERECONGNITION
{
	public uint dwSize;

	public int nCadidateNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CANDIDATE_INFO[] stCadidateInfo;

	public IntPtr pBuffer;

	public int nBufferLen;

	public bool bUseCandidatesEx;

	public int nCadidateExNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CANDIDATE_INFOEX[] stuCandidatesEx;
}
