// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COMPLIANT_VEHICLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COMPLIANT_VEHICLE_INFO
{
	public NET_VEHICLE_COLOR_INFO stuVehicleColor;

	public NET_VEHICLE_BRAND_INFO stuVehicleBrand;

	public NET_VEHICLE_TYPE_INFO stuVehicleType;

	public NET_VEHICLE_PLATE_COLOR_INFO stuVehiclePlateColor;

	public NET_VEHICLE_CALLING_INFO stuVehicleCalling;

	public NET_VEHICLE_SAFE_BELT_INFO stuVehicleSafeBelt;

	public NET_VEHICLE_ATTACHMENT_INFO stuVehicleAttachment;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
