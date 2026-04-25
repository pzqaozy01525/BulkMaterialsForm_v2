// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FIRING_GPS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FIRING_GPS_INFO
{
	public uint dwLongitude;

	public uint dwLatidude;

	public double dbAltitude;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szReserve;
}
