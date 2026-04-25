// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VEHICLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VEHICLE_INFO
{
	public uint nUID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szGroupName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPlateNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szPlateCountry;

	public int nPlateType;

	public int nVehicleType;

	public int nBrand;

	public int nCarSeries;

	public int nCarSeriesModelYearIndex;

	public NET_COLOR_RGBA stuVehicleColor;

	public NET_COLOR_RGBA stuPlateColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szOwnerName;

	public int nSex;

	public int nCertificateType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPersonID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szOwnerCountry;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szProvince;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCity;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szHomeAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szEmail;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPhoneNo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
