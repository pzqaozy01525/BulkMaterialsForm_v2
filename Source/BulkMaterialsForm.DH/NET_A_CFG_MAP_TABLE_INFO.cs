// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_MAP_TABLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_MAP_TABLE_INFO
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szServiceName;

	public EM_SERVICE_TYPE emServiceType;

	public EM_PROTOCOL_TYPE emProtocol;

	public uint nInnerPort;

	public uint nOuterPort;
}
