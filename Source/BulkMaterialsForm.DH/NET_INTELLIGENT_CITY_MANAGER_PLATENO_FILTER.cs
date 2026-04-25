// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_INTELLIGENT_CITY_MANAGER_PLATENO_FILTER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_INTELLIGENT_CITY_MANAGER_PLATENO_FILTER
{
	public EM_COMPARE_OPERATOR_TYPE emOperatorType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_STRING_32_PLATE_NO[] szPlateNo;

	public int nPlateCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
