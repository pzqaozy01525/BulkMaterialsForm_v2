// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_RADAR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_RADAR_INFO
{
	public float fCoordinateX;

	public float fCoordinateY;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public byte[] bReserved;
}
