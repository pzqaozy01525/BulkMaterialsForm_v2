// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_XRAY_CUSTOM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_XRAY_CUSTOM_INFO
{
	public EM_XRAY_VIEW_TYPE emViewType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSerialNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] byReserved;
}
