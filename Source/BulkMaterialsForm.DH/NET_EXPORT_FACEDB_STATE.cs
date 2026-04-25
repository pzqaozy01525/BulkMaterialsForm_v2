// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EXPORT_FACEDB_STATE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EXPORT_FACEDB_STATE
{
	public uint nProgress;

	public EM_EXPORT_FACEDB_ERRORCODE emErrorCode;

	public IntPtr pDataBuf;

	public uint dwDataLen;

	public int nLogicChannel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
	public byte[] byReserved;
}
