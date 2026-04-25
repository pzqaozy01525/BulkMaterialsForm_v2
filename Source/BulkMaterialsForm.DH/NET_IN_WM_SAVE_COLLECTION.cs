// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_WM_SAVE_COLLECTION

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_WM_SAVE_COLLECTION
{
	public uint dwSize;

	public int nMonitorWallID;

	public IntPtr pszName;

	public IntPtr pszControlID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string byReserved;

	public EM_SAVE_COLLECTION_TYPE emType;
}
