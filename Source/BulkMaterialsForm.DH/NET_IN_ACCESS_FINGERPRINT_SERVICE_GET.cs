// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ACCESS_FINGERPRINT_SERVICE_GET

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ACCESS_FINGERPRINT_SERVICE_GET
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserIDEx;

	public bool bUserIDEx;
}
