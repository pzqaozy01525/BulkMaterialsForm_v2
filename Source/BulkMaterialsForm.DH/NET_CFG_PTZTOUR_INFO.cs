// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZTOUR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZTOUR_INFO
{
	public int nCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_CFG_PTZTOUR_SINGLE[] stTours;
}
