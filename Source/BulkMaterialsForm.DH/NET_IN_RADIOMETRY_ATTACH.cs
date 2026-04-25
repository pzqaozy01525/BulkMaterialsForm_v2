// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_RADIOMETRY_ATTACH

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_RADIOMETRY_ATTACH
{
	public uint dwSize;

	public int nChannel;

	public fRadiometryAttachCB cbNotify;

	public IntPtr dwUser;
}
