// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_CLEAR_REPEAT_ENTER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_CLEAR_REPEAT_ENTER
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szCardNO;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
