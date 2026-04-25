// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEVICE_SEARCH_PARAM

namespace BulkMaterialsForm.DH;

public struct NET_DEVICE_SEARCH_PARAM
{
	public uint dwSize;

	public bool bUseDefault;

	public ushort wBroadcastLocalPort;

	public ushort wBroadcastRemotePort;

	public ushort wMulticastRemotePort;

	public bool bMulticastModifyRespond;

	public ushort wMulticastLocalPort;

	public int iAutoUpdatePortTimes;

	public ushort wAOLMulticastRemotePort;

	public ushort wAOLMulticastLocalPort;
}
