// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_MOTION_DATA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_MOTION_DATA
{
	public uint dwSize;

	public int nMotionDataCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_MOTION_DATA[] stMotionData;

	public int nRegionRow;

	public int nRegionCol;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_ROW[] byRegion;
}
