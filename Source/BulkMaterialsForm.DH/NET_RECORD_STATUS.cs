// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORD_STATUS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORD_STATUS
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] flag;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] Reserved;
}
