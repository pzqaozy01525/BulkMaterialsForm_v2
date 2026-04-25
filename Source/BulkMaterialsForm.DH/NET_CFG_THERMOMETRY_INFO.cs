// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_THERMOMETRY_INFO

namespace BulkMaterialsForm.DH;

public struct NET_CFG_THERMOMETRY_INFO
{
	public int nRelativeHumidity;

	public float fAtmosphericTemperature;

	public float fObjectEmissivity;

	public int nObjectDistance;

	public float fReflectedTemperature;

	public int nTemperatureUnit;

	public bool bIsothermEnable;

	public int nMinLimitTemp;

	public int nMediumTemp;

	public int nMaxLimitTemp;

	public int nSaturationTemp;

	public NET_CFG_RECT stIsothermRect;

	public bool bColorBarDisplay;

	public bool bHotSpotFollow;

	public bool bTemperEnable;

	public NET_CFG_RGBA stHighCTMakerColor;

	public NET_CFG_RGBA stLowCTMakerColor;
}
