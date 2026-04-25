// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MOTIONDETECT_REGION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MOTIONDETECT_REGION_INFO
{
	public uint nRegionID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRegionName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
	public byte[] bReserved;
}
