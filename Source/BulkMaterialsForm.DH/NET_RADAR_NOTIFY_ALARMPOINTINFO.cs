// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_NOTIFY_ALARMPOINTINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_NOTIFY_ALARMPOINTINFO
{
	public int nNumAlarmPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_RADAR_ALARMPOINT_INFO[] stuAlarmPoint;

	public int nChannel;

	public uint nRuleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_RADAR_RULE_INFO[] stuRuleInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 296)]
	public byte[] byReserved;
}
