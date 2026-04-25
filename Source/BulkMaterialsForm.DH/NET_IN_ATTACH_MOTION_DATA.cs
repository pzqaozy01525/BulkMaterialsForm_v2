// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_MOTION_DATA

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_MOTION_DATA
{
	public uint dwSize;

	public int nChannel;

	public fAttachMotionDataCB cbNotify;

	public IntPtr dwUser;
}
