// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_TRAFFIC_CAR_PART_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_TRAFFIC_CAR_PART_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szMachineName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRoadwayNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCategory;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 288)]
	public byte[] bReserved;
}
