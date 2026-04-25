// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_REGULATOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_REGULATOR_INFO
{
	public uint nDistance;

	public uint nTemperature;

	public NET_RECT stRect;

	public uint nHeight;

	public int nDiffTemperature;

	public int nEmissivity;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
	public byte[] byReserve;
}
