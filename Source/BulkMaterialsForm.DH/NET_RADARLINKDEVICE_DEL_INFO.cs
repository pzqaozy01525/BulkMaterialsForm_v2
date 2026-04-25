// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADARLINKDEVICE_DEL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADARLINKDEVICE_DEL_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSDLinkIP;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 224)]
	public byte[] byReserved;
}
