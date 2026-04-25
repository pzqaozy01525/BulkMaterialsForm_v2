// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_NETWORK_INTERFACE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_NETWORK_INTERFACE
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szIP;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szSubnetMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szDefGateway;

	public bool bDhcpEnable;

	public bool bDnsAutoGet;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] szDnsServers;

	public int nMTU;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szMacAddress;

	public bool bInterfaceEnable;

	public bool bReservedIPEnable;

	public CFG_ENUM_NET_TRANSMISSION_MODE emNetTranmissionMode;

	public CFG_ENUM_NET_INTERFACE_TYPE emInterfaceType;

	public CFG_THREE_STATUS_BOOL bBond;
}
