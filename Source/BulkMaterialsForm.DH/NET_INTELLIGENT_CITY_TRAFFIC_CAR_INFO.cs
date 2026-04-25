// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_INTELLIGENT_CITY_TRAFFIC_CAR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_INTELLIGENT_CITY_TRAFFIC_CAR_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPlateNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleLogo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleSeries;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleType;

	public uint nParkingDuration;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
