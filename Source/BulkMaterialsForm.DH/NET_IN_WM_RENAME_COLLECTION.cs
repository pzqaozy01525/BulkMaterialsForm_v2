// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_WM_RENAME_COLLECTION

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_WM_RENAME_COLLECTION
{
	public uint dwSize;

	public int nMonitorWallID;

	public IntPtr pszOldName;

	public IntPtr pszNewName;
}
