// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PASSED_SUBTOTAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PASSED_SUBTOTAL_INFO
{
	public int nTotal;

	public int nHour;

	public int nToday;

	public int nTotalInTimeSection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 112)]
	public string szReserved;
}
