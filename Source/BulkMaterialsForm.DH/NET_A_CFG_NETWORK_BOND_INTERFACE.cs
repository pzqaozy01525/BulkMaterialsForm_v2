// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_NETWORK_BOND_INTERFACE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_NETWORK_BOND_INTERFACE
{
	public bool bBonding;

	public EM_A_CFG_ENUM_NET_BOND_MODE emMode;

	public EM_A_CFG_ENUM_NET_BOND_LACP emLacp;

	public int nMTU;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMembers;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szIP;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAlias;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szDnsServers;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMacAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szSubnetMask;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDefGateway;

	public bool bDhcpEnable;
}
