// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_NETWORK_BR_INTERFACE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_NETWORK_BR_INTERFACE
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public bool bEnable;

	public int nMTU;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMembers;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szIP;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szSubnetMask;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDefGateway;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szDnsServers;

	public bool bDhcpEnable;

	public bool bReservedIPEnable;

	public bool bDnsAutoGet;
}
