// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_BUS_ATTACH

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_BUS_ATTACH
{
	public uint dwSize;

	public fBusStateCallBack cbBusState;

	public IntPtr dwUser;
}
