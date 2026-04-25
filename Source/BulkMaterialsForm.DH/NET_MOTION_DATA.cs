// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MOTION_DATA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MOTION_DATA
{
	public int nRegionID;

	public int nThreshold;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
