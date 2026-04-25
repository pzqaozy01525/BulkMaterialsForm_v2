// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_CUSTOM_SNAP_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_CUSTOM_SNAP_INFO
{
	public uint dwSize;

	public int nChannelID;

	public fAttachCustomSnapInfo cbCustomSnapInfo;

	public IntPtr dwUser;
}
