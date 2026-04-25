// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_PLACE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_PLACE_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] nRadarPixel;

	public double dbRadarAngle;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string byReserved;
}
