// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_UUID_CHAR

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_UUID_CHAR
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUUID;
}
