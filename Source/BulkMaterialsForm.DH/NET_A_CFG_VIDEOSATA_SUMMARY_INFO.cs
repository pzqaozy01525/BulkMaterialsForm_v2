// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_CFG_VIDEOSATA_SUMMARY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_CFG_VIDEOSATA_SUMMARY_INFO
{
	public int nStructSize;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleName;

	public NET_A_CFG_NET_TIME_EX stuStatTime;

	public int nEnteredTotal;

	public int nEnteredToday;

	public int nEnteredMonth;

	public int nEnteredYear;

	public int nEnteredDaily;

	public int nExitedTotal;

	public int nExitedToday;

	public int nExitedMonth;

	public int nExitedYear;

	public int nExitedDaily;

	public int nAvgTotal;

	public int nAvgToday;

	public int nAvgMonth;

	public int nAvgYear;

	public int nMaxTotal;

	public int nMaxToday;

	public int nMaxMonth;

	public int nMaxYear;

	public int nInsideSubTotal;

	public EM_CFG_RULE_TYPE emRuleType;

	public int nRetExitManNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_A_CFG_EXITMAN_STAY_STAT[] stuExitManStayInfo;

	public uint nEnteredTotalPig;

	public uint nEnteredHourPig;

	public uint nEnteredTodayPig;

	public uint nEnteredTotalPigInTimeSection;

	public uint nExitedTotalPig;

	public uint nExitedHourPig;

	public uint nExitedTodayPig;

	public uint nExitedTotalPigInTimeSection;

	public uint nInsideTotalPig;

	public int nInsidePigStayStatCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_A_CFG_PIG_STAY_STAT[] stuInsidePigStayStatInfo;

	public uint nInsideTodayPig;
}
