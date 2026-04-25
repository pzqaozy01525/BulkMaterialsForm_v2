// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NETSDK_INIT_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NETSDK_INIT_PARAM
{
	public int nThreadNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
