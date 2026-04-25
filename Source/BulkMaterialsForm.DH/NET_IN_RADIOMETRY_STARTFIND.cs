// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_RADIOMETRY_STARTFIND

namespace BulkMaterialsForm.DH;

public struct NET_IN_RADIOMETRY_STARTFIND
{
	public uint dwSize;

	public NET_TIME stStartTime;

	public NET_TIME stEndTime;

	public int nMeterType;

	public int nChannel;

	public EM_RADIOMETRY_PERIOD emPeriod;
}
