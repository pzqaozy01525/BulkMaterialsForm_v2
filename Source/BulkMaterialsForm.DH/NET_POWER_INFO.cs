// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_POWER_INFO

namespace BulkMaterialsForm.DH;

public struct NET_POWER_INFO
{
	public uint dwSize;

	public bool bPowerOn;

	public EM_CURRENT_STATE_TYPE emCurrentState;

	public EM_VOLTAGE_STATE_TYPE emVoltageState;
}
