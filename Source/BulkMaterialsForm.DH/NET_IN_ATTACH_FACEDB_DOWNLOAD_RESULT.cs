// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_FACEDB_DOWNLOAD_RESULT

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_FACEDB_DOWNLOAD_RESULT
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public fFaceDbDownLoadResult cbFaceDbDownLoadResult;

	public IntPtr dwUser;
}
