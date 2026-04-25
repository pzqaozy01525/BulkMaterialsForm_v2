// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VEHICLE_BRAND_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VEHICLE_BRAND_INFO
{
	public bool bEnable;

	public int nShowListNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nBrandShowList;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
