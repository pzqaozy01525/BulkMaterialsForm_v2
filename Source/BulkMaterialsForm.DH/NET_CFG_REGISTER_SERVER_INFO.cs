// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_REGISTER_SERVER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_REGISTER_SERVER_INFO
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDeviceID;

	public int nServersNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_SERVER_INFO[] stuServers;
}
