// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_EXITMAN_STAY_STAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_EXITMAN_STAY_STAT
{
	public NET_A_CFG_NET_TIME_EX stuEnterTime;

	public NET_A_CFG_NET_TIME_EX stuExitTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 104)]
	public byte[] reserved;
}
