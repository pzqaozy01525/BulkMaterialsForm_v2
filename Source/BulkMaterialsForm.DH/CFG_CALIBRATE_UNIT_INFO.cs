// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_CALIBRATE_UNIT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_CALIBRATE_UNIT_INFO
{
	public uint nHeight;

	public uint nWidth;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public float[] nPosition;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public uint[] nLocation;

	public uint nHFOV;

	public uint nVFOV;
}
