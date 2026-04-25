// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BATTERY_INFO

namespace BulkMaterialsForm.DH;

public struct NET_BATTERY_INFO
{
	public uint dwSize;

	public int nPercent;

	public bool bCharging;

	public EM_BATTERY_EXIST_STATE emExistState;

	public EM_BATTERY_STATE emState;

	public float fVoltage;

	public EM_BATTERY_TEMPER_STATE emTemperState;
}
