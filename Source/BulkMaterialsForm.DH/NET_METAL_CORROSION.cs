// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_METAL_CORROSION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_METAL_CORROSION
{
	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string bReserved;
}
