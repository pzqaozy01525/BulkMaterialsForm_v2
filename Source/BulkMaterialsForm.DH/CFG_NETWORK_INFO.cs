// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.CFG_NETWORK_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct CFG_NETWORK_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szHostName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDomain;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDefInterface;

	public int nInterfaceNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public CFG_NETWORK_INTERFACE[] stuInterfaces;

	public int nBondInterfaceNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_A_CFG_NETWORK_BOND_INTERFACE[] stuBondInterfaces;

	public int nBrInterfaceNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_A_CFG_NETWORK_BR_INTERFACE[] stuBrInterfaces;
}
