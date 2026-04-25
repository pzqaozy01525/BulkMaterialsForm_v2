// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_FINGERPRINT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_FINGERPRINT_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public int nPacketLen;

	public int nPacketNum;

	public IntPtr szFingerPrintInfo;

	public int nDuressIndex;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
	public byte[] byReserved;
}
