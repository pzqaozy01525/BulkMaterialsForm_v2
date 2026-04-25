// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_LOCATION_CALIBRATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_LOCATION_CALIBRATE_INFO
{
	public uint nVisualMaxHFOV;

	public uint nVisualMaxVFOV;

	public uint nThermoMaxHFOV;

	public uint nThermoMaxVFOV;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public CFG_LOCATION_CALIBRATE_POINT_INFO[] stuPointInfo;

	public int nPointNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;
}
