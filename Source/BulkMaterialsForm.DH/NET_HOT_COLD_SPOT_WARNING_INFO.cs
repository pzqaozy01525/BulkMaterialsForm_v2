// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HOT_COLD_SPOT_WARNING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HOT_COLD_SPOT_WARNING_INFO
{
	public uint dwSize;

	public bool bHotAlarmEnable;

	public bool bColdAlarmEnable;

	public EM_HOT_ALARM_CONDITION emHotAlarmCondition;

	public EM_COLD_ALARM_CONDITION emColdAlarmCondition;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public double dHotThreshold;

	public double dColdThreshold;

	public bool bHotSpotLinkEnable;

	public bool bColdSpotLinkEnable;

	public NET_CFG_ALARM_MSG_HANDLE stuEventHandler;
}
