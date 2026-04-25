// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RFIDELETAG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RFIDELETAG_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szCardID;

	public int nCardType;

	public EM_CARD_PROVINCE emCardPrivince;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szPlateNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szProductionDate;

	public EM_CAR_TYPE emCarType;

	public int nPower;

	public int nDisplacement;

	public int nAntennaID;

	public EM_PLATE_TYPE emPlateType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szInspectionValidity;

	public int nInspectionFlag;

	public int nMandatoryRetirement;

	public EM_CAR_COLOR_TYPE emCarColor;

	public int nApprovedCapacity;

	public int nApprovedTotalQuality;

	public NET_TIME_EX stuThroughTime;

	public EM_USE_PROPERTY_TYPE emUseProperty;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] szPlateCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szPlateSN;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 104)]
	public byte[] bReserved;
}
