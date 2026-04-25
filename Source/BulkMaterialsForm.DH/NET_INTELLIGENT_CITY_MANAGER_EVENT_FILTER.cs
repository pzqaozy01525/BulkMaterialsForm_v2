// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_INTELLIGENT_CITY_MANAGER_EVENT_FILTER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_INTELLIGENT_CITY_MANAGER_EVENT_FILTER
{
	public EM_COMPARE_OPERATOR_TYPE emOperatorType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public int[] nEventList;

	public int nEventCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
