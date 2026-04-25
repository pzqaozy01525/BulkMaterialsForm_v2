// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_LOCATION_CALIBRATE_POINT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_LOCATION_CALIBRATE_POINT_INFO
{
	public uint nID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

	public bool bEnable;

	public uint nLongitude;

	public uint nLatitude;

	public double fAltitude;

	public CFG_CALIBRATE_INFO stuCalibrateInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;
}
