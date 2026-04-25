// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CARDNOARRAY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CARDNOARRAY_INFO
{
	public int nCardNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 320)]
	public string szCardInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
