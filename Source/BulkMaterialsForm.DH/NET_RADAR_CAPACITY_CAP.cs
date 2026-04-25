// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_CAPACITY_CAP

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_CAPACITY_CAP
{
	public bool bSupport;

	public int nListNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public int[] nDistanceList;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
	public byte[] byReserved;
}
