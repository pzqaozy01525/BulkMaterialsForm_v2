// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESS_TIMESCHEDULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESS_TIMESCHEDULE_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
	public NET_CFG_TIME_SECTION[] stuTime;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
	public int[] nTimeScheduleConsumptionTimes;

	public int nConsumptionStrategyNums;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1428)]
	public string szConsumptionStrategy;
}
