// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_BURNSTATE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_CB_BURNSTATE
{
	public uint dwSize;

	public IntPtr szState;

	public IntPtr szFileName;

	public uint dwTotalSpace;

	public uint dwRemainSpace;

	public IntPtr szDeviceName;

	public int nRemainTime;
}
