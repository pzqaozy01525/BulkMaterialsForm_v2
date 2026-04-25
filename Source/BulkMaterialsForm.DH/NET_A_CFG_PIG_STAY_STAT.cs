// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_PIG_STAY_STAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_PIG_STAY_STAT
{
	public NET_CFG_NET_TIME stuEnterTime;

	public NET_CFG_NET_TIME stuExitTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 200)]
	public string szReserved;
}
