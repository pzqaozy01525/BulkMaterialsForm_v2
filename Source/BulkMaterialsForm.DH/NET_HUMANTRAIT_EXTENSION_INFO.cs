// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMANTRAIT_EXTENSION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMANTRAIT_EXTENSION_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
	public string szAdditionalCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
