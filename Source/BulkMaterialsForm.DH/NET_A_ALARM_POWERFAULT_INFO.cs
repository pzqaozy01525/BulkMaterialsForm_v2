// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_POWERFAULT_INFO

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_POWERFAULT_INFO
{
	public uint dwSize;

	public EM_POWER_TYPE emPowerType;

	public EM_POWERFAULT_EVENT_TYPE emPowerFaultEvent;

	public NET_TIME stuTime;

	public int nAction;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
