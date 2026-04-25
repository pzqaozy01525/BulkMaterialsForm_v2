// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_EXECUTE_CLOUD_UPGRADER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_EXECUTE_CLOUD_UPGRADER
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNewVersion;

	public uint nWay;

	public NET_PROXY_SERVER_INFO stProxy;

	public NET_CLOUD_UPGRADER_INFO stInfo;
}
