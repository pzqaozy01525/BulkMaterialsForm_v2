// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RADAR_MAPPARA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RADAR_MAPPARA_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public NET_RADAR_PIXELLINE stuPixelLine;

	public double dDistance;

	public NET_RADAR_PIXELPOINT stuPixelPoint;

	public double dRadarDirectionAngle;

	public uint nLongitudeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public int[] nLongitude;

	public uint nLatitudeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public int[] nLatitude;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string byReserved1;

	public uint nRadarPlaceNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_RADAR_PLACE_INFO[] stuRadarPlaceInfo;
}
