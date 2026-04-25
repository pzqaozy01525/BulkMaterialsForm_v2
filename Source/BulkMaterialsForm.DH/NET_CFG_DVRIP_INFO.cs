// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_DVRIP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_DVRIP_INFO
{
	public int nTcpPort;

	public int nSSLPort;

	public int nUDPPort;

	public int nMaxConnections;

	public bool bMCASTEnable;

	public int nMCASTPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMCASTAddress;

	public int nRegistersNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_REGISTER_SERVER_INFO[] stuRegister;

	public EM_STREAM_POLICY emStreamPolicy;

	public NET_CFG_REGISTERSERVER_VEHICLE stuRegisterServerVehicle;
}
