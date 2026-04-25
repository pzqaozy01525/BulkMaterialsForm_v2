// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COMPLIANT_BOAT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COMPLIANT_BOAT_INFO
{
	public NET_BOAT_TYPE_INFO stuBoatType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
