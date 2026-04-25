// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_TRANSMIT_INFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_TRANSMIT_INFO
{
	public uint dwSize;

	public NET_TRANSMIT_INFO_TYPE emType;

	public IntPtr szInJsonBuffer;

	public uint dwInJsonBufferSize;

	public IntPtr szInBinBuffer;

	public uint dwInBinBufferSize;

	public EM_TRANSMIT_ENCRYPT_TYPE emEncryptType;
}
