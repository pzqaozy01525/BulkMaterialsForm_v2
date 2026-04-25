// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_UID_CHAR

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_UID_CHAR
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUID;
}
