// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_OCCUPIED_WARNING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_OCCUPIED_WARNING_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szParkingNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 320)]
	public string szPlateNumber;

	public int nPlateNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
	public byte[] bReserved;
}
