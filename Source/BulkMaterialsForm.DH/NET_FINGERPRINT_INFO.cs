// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FINGERPRINT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FINGERPRINT_INFO
{
	public int nFingerNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16384)]
	public string szFingerInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
