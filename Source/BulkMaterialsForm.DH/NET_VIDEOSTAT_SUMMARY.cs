// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VIDEOSTAT_SUMMARY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VIDEOSTAT_SUMMARY
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szRuleName;

	public NET_TIME_EX stuTime;

	public NET_VIDEOSTAT_SUBTOTAL stuEnteredSubtotal;

	public NET_VIDEOSTAT_SUBTOTAL stuExitedSubtotal;

	public uint nInsidePeopleNum;

	public EM_RULE_TYPE emRuleType;

	public int nRetExitManNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_EXITMAN_STAY_STAT[] stuExitManStayInfo;

	public uint nPlanID;

	public uint nAreaID;

	public uint nCurrentDayInsidePeopleNum;

	public uint nInsideTotalNonMotor;

	public uint nInsideTodayNonMotor;

	public int nRetNonMotorNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_NONMOTOR_STAY_STAT[] stuNonMotorStayStat;

	public uint nInsideTotalPig;

	public int nPigStayStatCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_PIG_STAY_STAT[] stuPigStayStatInfo;

	public uint nInsideTodayPig;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved;

	public NET_PASSED_SUBTOTAL_INFO stuPassedSubtotal;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 884)]
	public byte[] reserved;
}
