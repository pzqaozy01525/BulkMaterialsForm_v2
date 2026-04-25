// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VEHICLE_ATTACH

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VEHICLE_ATTACH
{
	public int nType;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
