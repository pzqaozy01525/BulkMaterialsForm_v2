// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFIC_FLOWSTAT_ALARM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFIC_FLOWSTAT_ALARM_INFO
{
	public byte bEnable;

	public int nPeriod;

	public int nLimit;

	public int nRestore;

	public int nDelay;

	public int nInterval;

	public int nReportTimes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
	public NET_CFG_TIME_SECTION[] stCurrentTimeSection;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;
}
