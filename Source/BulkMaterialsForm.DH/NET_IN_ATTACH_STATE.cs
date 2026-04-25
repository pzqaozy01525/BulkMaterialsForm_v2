// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_STATE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_STATE
{
	public uint dwSize;

	public IntPtr szDeviceName;

	public fAttachBurnStateCB cbAttachState;

	public IntPtr dwUser;

	public IntPtr lBurnSession;

	public fAttachBurnStateCBEx cbAttachStateEx;

	public IntPtr dwUserEx;
}
