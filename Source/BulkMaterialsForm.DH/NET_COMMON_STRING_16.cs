// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COMMON_STRING_16

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COMMON_STRING_16
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szContent;
}
