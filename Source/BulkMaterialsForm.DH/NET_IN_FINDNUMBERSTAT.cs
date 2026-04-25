// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FINDNUMBERSTAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FINDNUMBERSTAT
{
	public uint dwSize;

	public int nChannelID;

	public NET_TIME stStartTime;

	public NET_TIME stEndTime;

	public int nGranularityType;

	public int nWaittime;

	public uint nPlanID;

	public EM_RULE_TYPE emRuleType;

	public int nMinStayTime;

	public int nAreaIDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public uint[] nAreaID;

	public EM_OTHER_RULE_TYPE emOtherRule;

	public int nGranularityExt;
}
