// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAVEL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAVEL_INFO
{
	public EM_TRAVEL_CODE_COLOR emTravelCodeColor;

	public int nCityCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szPassingCity;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
