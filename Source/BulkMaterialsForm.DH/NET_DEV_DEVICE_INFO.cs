// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_DEVICE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_DEVICE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string byModle;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string bySerialNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string byFirmWare;

	public int nAtaVersion;

	public int nSmartNum;

	public long Sectors;

	public int nStatus;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 33)]
	public int[] nReserved;
}
