// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_TASK_MODULE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_TASK_MODULE
{
	public NET_CFG_SIZEFILTER_INFO stuSizeFileter;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_POLY_POINTS[] stuExcludeRegion;

	public int nExcludeRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
