// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IMPORT_FACEDB_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IMPORT_FACEDB_STATE
{
	public uint nProgress;

	public EM_FACEDB_PROGRESS_TYPE emType;

	public EM_IMPORT_FACEDB_STATE emState;

	public int nLogicChannel;

	public int nDeploySuccessNum;

	public int nTotalNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 500)]
	public byte[] byReserved;
}
