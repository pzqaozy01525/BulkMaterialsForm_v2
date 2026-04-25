// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_INTELLI_COMM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_INTELLI_COMM_INFO
{
	public EM_CLASS_TYPE emClassType;

	public int nPresetID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] bReserved;
}
