// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_TRANSMIT_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_TRANSMIT_INFO
{
	public uint dwSize;

	public IntPtr szOutBuffer;

	public uint dwOutBufferSize;

	public uint dwOutJsonLen;

	public uint dwOutBinLen;
}
