// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_VIDEOIN_EXPOSURE_BASE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_VIDEOIN_EXPOSURE_BASE
{
	public bool bSlowShutter;

	public byte byExposureMode;

	public byte byAntiFlicker;

	public byte byCompensation;

	public byte byAutoGainMax;

	public byte byGain;

	public byte bySlowAutoExposure;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bybyReserv;

	public int byExposureSpeed;

	public byte bySlowSpeed;

	public byte byIris;

	public byte byBacklight;

	public byte byWideDynamicRange;

	public byte byWideDynamicRangeMode;

	public byte byGlareInhibition;

	public byte byDoubleExposure;

	public byte byReserved;

	public int nRecoveryTime;

	public float fValue1;

	public float fValue2;

	public NET_CFG_RECT stuBacklightRegion;

	public byte byIrisMin;

	public byte byIrisMax;

	public byte byGainMin;

	public byte byGainMax;
}
