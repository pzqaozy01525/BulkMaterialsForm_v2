// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_POLY_POINTS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_POLY_POINTS
{
	public int nPointNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuPoints;
}
