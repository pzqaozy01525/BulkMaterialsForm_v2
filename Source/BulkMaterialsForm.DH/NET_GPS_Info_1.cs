// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GPS_Info

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GPS_Info
{
	public NET_TIME revTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public byte[] DvrSerial;

	public double longitude;

	public double latidude;

	public double height;

	public double angle;

	public double speed;

	public ushort starCount;

	public bool antennaState;

	public bool orientationState;
}
