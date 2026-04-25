// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BATCH_APPEND_PERSON_RESULT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BATCH_APPEND_PERSON_RESULT
{
	public uint nUID;

	public uint dwErrorCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUID2;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 448)]
	public byte[] bReserved;
}
