// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_WM_SET_WORK_MODE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_WM_SET_WORK_MODE
{
	public uint dwSize;

	public int nChannel;

	public IntPtr pszCompositeID;

	public int nWindow;

	public EM_NET_WM_WORK_MODE emMode;
}
