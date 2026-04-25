// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EXTENSION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EXTENSION_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 52)]
	public string szEventID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 80)]
	public byte[] byReserved;
}
