// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FIND_RECORD_ACCESSCTLCARDREC_ORDER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FIND_RECORD_ACCESSCTLCARDREC_ORDER
{
	public EM_RECORD_ACCESSCTLCARDREC_ORDER_FIELD emField;

	public EM_RECORD_ORDER_TYPE emOrderType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] byReverse;
}
