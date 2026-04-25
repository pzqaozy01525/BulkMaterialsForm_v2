// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_NUMBERSTAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_NUMBERSTAT
{
	public uint dwSize;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szRuleName;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public int nEnteredSubTotal;

	public int nExitedSubtotal;

	public int nAvgInside;

	public int nMaxInside;

	public int nEnteredWithHelmet;

	public int nEnteredWithoutHelmet;

	public int nExitedWithHelmet;

	public int nExitedWithoutHelmet;

	public int nInsideSubtotal;

	public uint nPlanID;

	public uint nAreaID;

	public uint nAverageStayTime;

	public NET_TEMPERATURE_STATISTICS_INFO stuTempInfo;

	public int nPassedSubtotal;
}
