// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_DEVICETYPE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_DEVICETYPE_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szTypeEx;
}
