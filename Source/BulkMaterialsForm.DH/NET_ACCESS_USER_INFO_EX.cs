// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_USER_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_USER_INFO_EX
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1428)]
	public string szConsumptionTimeSections;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
