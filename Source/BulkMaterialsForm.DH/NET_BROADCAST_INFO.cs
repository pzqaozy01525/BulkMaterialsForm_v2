// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BROADCAST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BROADCAST_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szText;

	public EM_BROADCAST_TEXT_TYPE emTextType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] byReserved;
}
