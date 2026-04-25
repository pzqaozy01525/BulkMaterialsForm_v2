// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_UNIFIEDINFOCOLLECT_GET_DEVSTATUS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_UNIFIEDINFOCOLLECT_GET_DEVSTATUS
{
	public uint dwSize;

	public NET_DEVSTATUS_POWER_INFO stuPowerInfo;

	public NET_DEVSTATUS_NET_INFO stuNetInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVersion;

	public EM_A_NET_EM_TAMPER_STATE emTamperState;
}
