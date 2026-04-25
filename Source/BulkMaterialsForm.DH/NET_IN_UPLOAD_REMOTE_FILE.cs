// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_UPLOAD_REMOTE_FILE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_UPLOAD_REMOTE_FILE
{
	public uint dwSize;

	public IntPtr pszFileSrc;

	public IntPtr pszFileDst;

	public IntPtr pszFolderDst;

	public uint nPacketLen;

	public uint nTimeOut;
}
