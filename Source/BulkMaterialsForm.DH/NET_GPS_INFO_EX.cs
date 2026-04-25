// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GPS_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GPS_INFO_EX
{
	public int nLongitude;

	public int nLatidude;

	public double nAltitude;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szReserved;
}
