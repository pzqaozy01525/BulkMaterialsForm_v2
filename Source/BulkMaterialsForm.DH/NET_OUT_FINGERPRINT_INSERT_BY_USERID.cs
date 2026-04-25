// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_FINGERPRINT_INSERT_BY_USERID

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_FINGERPRINT_INSERT_BY_USERID
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public int[] nFingerPrintID;

	public int nReturnedCount;

	public int nFailedCode;
}
