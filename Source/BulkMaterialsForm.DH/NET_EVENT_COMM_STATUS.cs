// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_COMM_STATUS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_COMM_STATUS
{
	public byte bySmoking;

	public byte byCalling;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
	public byte[] szReserved;
}
