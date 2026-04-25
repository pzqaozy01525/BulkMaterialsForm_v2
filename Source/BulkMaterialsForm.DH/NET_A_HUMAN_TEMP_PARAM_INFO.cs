// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_HUMAN_TEMP_PARAM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_HUMAN_TEMP_PARAM_INFO
{
	public int nTempPickTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] byReserved;
}
