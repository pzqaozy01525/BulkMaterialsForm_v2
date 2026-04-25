// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_PROTOCAL_CAP

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_PROTOCAL_CAP
{
	public bool bSupport;

	public uint nProtocalNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 320)]
	public string szPtotoList;

	public int nLongitude;

	public int nLatitude;

	public int nAngle;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
