// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CUSTOM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CUSTOM_INFO
{
	public int nCargoChannelNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public float[] fCoverageRate;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
	public byte[] byReserved;
}
