// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_GPS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_GPS_INFO
{
	public double dLongitude;

	public double dLatitude;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public byte[] bReserved;
}
