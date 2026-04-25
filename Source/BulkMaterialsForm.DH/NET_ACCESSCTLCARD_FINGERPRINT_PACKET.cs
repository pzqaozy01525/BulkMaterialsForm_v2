// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESSCTLCARD_FINGERPRINT_PACKET

using System;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESSCTLCARD_FINGERPRINT_PACKET
{
	public uint dwSize;

	public int nLength;

	public int nCount;

	public IntPtr pPacketData;
}
