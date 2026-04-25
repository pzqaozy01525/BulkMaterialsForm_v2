// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_FACEDB_DOWNLOAD_RESULT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_FACEDB_DOWNLOAD_RESULT
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szFaceDbVersion;

	public uint nTotalDownloadCount;

	public uint nSuccessDownloadCount;

	public EM_FACEDB_ERRCODE emFaceDbErrCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 960)]
	public byte[] byReserved;
}
