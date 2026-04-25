// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADARLINKDEVICE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADARLINKDEVICE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSDLinkIP;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVendor;

	public int nPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPassword;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDeviceType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] byReserved;
}
