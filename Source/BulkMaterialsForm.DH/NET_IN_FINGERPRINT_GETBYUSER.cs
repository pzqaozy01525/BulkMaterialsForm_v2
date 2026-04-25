// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FINGERPRINT_GETBYUSER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FINGERPRINT_GETBYUSER
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;
}
