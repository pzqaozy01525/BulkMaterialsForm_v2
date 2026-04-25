// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_OVERSPEED_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_OVERSPEED_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] nSpeedingPercentage;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDescription;
}
