// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HISTORY_TRAFFIC_CAR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HISTORY_TRAFFIC_CAR_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUID;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCategory;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSpecialCar;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szVehicleSign;

	public uint nSubBrand;

	public uint nBrandYear;

	public uint nFurnitureCount;

	public uint nPendantCount;

	public uint nAnnualInspectionCount;

	public int nAnnualInspectionShape;

	public EM_NET_SUNSHADE_STATE emSunShade;

	public EM_NET_SUNSHADE_STATE emSubSeatSunShade;

	public uint nCardCount;

	public EM_NET_SAFEBELT_STATE emSafeBelt;

	public int nCalling;

	public int nPlayPhone;

	public int nSmoking;

	public int nSubSeatPeople;

	public EM_NET_SAFEBELT_STATE emSubSeatSafeBelt;

	public int nHoldBaby;

	public int nSunroof;

	public int nLuggageRack;

	public int nVehicleCollision;

	public int nVehiclePrint;

	public int nBackupTire;

	public int nTrunk;

	public int nPlateAttribute;

	public int nMuskHide;

	public NET_PIC_INFO_EX2 stuImage;

	public int nPressParkingStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
