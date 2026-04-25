// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESSCTLCARD_FINGERPRINT_PACKET_EX

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESSCTLCARD_FINGERPRINT_PACKET_EX
{
	public int nLength;

	public int nCount;

	public IntPtr pPacketData;

	public int nPacketLen;

	public int nRealPacketLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReverseed;
}
