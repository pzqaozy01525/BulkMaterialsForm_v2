// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GPS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct NET_GPS_INFO
{
	public uint nLongitude;

	public uint nLatidude;

	public double dbAltitude;

	public double dbSpeed;

	public double dbBearing;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] bReserved;
}
