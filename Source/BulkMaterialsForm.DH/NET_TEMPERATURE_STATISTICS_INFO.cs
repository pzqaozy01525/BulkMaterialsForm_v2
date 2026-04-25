// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TEMPERATURE_STATISTICS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TEMPERATURE_STATISTICS_INFO
{
	public uint nTotalCount;

	public uint nHighTempCount;

	public uint nLowTempCount;

	public uint nNormalTempCount;

	public uint nNoMaskCount;

	public uint nTimeKey;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
