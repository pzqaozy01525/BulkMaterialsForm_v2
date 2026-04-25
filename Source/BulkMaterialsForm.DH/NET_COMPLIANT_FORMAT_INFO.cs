// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COMPLIANT_FORMAT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COMPLIANT_FORMAT_INFO
{
	public bool bSupportHuman;

	public NET_COMPLIANT_HUMAN_INFO stuHuman;

	public bool bSupportVehicle;

	public NET_COMPLIANT_VEHICLE_INFO stuVehicle;

	public bool bSupportNonMotor;

	public NET_COMPLIANT_NONMOTOR_INFO stuNonMotor;

	public NET_COMPLIANT_BOAT_INFO stuBoat;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
