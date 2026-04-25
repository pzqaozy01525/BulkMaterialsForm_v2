// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEVSTATUS_NET_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEVSTATUS_NET_INFO
{
	public uint nWifiIntensity;

	public uint nWifiSignal;

	public uint nCellulSignal;

	public uint nCellulIntensity;

	public EM_A_NET_EM_ETH_STATE emEthState;

	public uint n3Gflux;

	public uint n3GfluxByTime;

	public EM_A_NET_EM_ETH_STATE emWifiState;

	public EM_A_NET_EM_ETH_STATE emCellularstate;

	public uint nSimNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_DEVSTATUS_SIM_INFO[] stuSimInfo;
}
