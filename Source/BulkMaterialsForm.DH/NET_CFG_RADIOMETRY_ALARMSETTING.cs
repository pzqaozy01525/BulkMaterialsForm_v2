// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RADIOMETRY_ALARMSETTING

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RADIOMETRY_ALARMSETTING
{
	public int nId;

	public bool bEnable;

	public int nResultType;

	public int nAlarmCondition;

	public float fThreshold;

	public float fHysteresis;

	public int nDuration;
}
