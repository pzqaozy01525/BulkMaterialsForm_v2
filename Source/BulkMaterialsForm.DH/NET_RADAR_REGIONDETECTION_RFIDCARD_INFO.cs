// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_REGIONDETECTION_RFIDCARD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_REGIONDETECTION_RFIDCARD_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
	public string szCardID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string byReserved;
}
