// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FUEL_DISPENSER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FUEL_DISPENSER_INFO
{
	public uint nFuelingStartTime;

	public uint nFuelingEndTime;

	public uint nMoney;

	public uint nLitre;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szOilType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szReserved;
}
