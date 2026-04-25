// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FINGERPRINT_INSERT_BY_USERID

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FINGERPRINT_INSERT_BY_USERID
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public int nSinglePacketLen;

	public int nPacketCount;

	public IntPtr szFingerPrintInfo;
}
