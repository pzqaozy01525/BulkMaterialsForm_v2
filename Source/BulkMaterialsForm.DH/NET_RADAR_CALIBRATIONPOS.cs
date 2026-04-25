// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_CALIBRATIONPOS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_CALIBRATIONPOS
{
	public NET_RADAR_PIXELPOINT stuPixelPoint;

	public double dPositionX;

	public double dPositionY;

	public double dZoom;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
