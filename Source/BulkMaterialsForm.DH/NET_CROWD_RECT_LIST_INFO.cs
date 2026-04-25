// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CROWD_RECT_LIST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CROWD_RECT_LIST_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_POINT[] stuRectPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
