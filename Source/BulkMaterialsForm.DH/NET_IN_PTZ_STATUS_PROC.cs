// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_PTZ_STATUS_PROC

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_PTZ_STATUS_PROC
{
	public uint dwSize;

	public int nChannel;

	public fPTZStatusProcCallBack cbPTZStatusProc;

	public IntPtr dwUser;
}
