// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DREGS_UNCOVERED_VEHICLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DREGS_UNCOVERED_VEHICLE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPlateNumber;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
