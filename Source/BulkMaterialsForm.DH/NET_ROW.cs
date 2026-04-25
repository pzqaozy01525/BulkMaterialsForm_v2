// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ROW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ROW
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byCol;
}
