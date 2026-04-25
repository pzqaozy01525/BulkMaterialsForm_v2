// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_EVENT_VEHICLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_EVENT_VEHICLE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCategory;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] byReserved;
}
