// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_LIST_REMOTE_FILE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_LIST_REMOTE_FILE
{
	public uint dwSize;

	public IntPtr pstuFiles;

	public int nMaxFileCount;

	public int nRetFileCount;
}
