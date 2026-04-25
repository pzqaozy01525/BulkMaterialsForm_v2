// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GESTURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GESTURE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szType;

	public uint nCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szReserved;
}
