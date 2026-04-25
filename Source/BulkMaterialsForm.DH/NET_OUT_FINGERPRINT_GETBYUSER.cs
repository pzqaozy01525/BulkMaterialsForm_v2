// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_FINGERPRINT_GETBYUSER

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_FINGERPRINT_GETBYUSER
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public int[] nFingerPrintIDs;

	public int nRetFingerPrintCount;

	public int nSinglePacketLength;

	public int nMaxFingerDataLength;

	public int nRetFingerDataLength;

	public IntPtr pbyFingerData;
}
