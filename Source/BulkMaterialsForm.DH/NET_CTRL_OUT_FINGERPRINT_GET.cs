// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_OUT_FINGERPRINT_GET

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_OUT_FINGERPRINT_GET
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szFingerPrintName;

	public int nFingerPrintID;

	public int nRetLength;

	public int nMaxFingerDataLength;

	public IntPtr szFingerPrintInfo;
}
