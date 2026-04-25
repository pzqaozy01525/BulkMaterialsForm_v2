// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEVSTATUS_SIM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEVSTATUS_SIM_INFO
{
	public EM_A_NET_EM_SIM_STATE emStatus;

	public byte byIndex;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 31)]
	public byte[] byReserved;
}
