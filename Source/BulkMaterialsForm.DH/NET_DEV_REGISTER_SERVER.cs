// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_REGISTER_SERVER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_REGISTER_SERVER
{
	public uint dwSize;

	public byte bServerNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_DEV_SERVER_INFO[] lstServer;

	public byte bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDeviceID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 94)]
	public byte[] reserved;
}
