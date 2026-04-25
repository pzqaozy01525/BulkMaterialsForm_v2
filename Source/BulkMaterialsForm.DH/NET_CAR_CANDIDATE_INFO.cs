// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CAR_CANDIDATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CAR_CANDIDATE_INFO
{
	public NET_VEHICLE_INFO stuVehicleInfo;

	public int nDifferentAttributresNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public int[] nDifferentAttributres;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
