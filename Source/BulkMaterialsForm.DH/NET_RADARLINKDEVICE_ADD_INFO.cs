// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADARLINKDEVICE_ADD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADARLINKDEVICE_ADD_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSDLinkIP;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPassword;

	public int nPort;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 316)]
	public byte[] byReserved;
}
