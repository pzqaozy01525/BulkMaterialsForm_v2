// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_DAHUA_RADAR_CONFIG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_DAHUA_RADAR_CONFIG
{
	public int nAngle;

	public bool bLowSpeed;

	public bool bSpeedForSize;

	public NET_RADAR_CARSPEED_INFO stuSmallCarSpeed;

	public NET_RADAR_CARSPEED_INFO stuMediumCarSpeed;

	public NET_RADAR_CARSPEED_INFO stuBigCarSpeed;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szName;

	public int nSensitivity;

	public int nDetectMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
