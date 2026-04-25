// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GUIDE_MODULE_MEASURE_MODE_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GUIDE_MODULE_MEASURE_MODE_PARAM
{
	public bool bRectEnable;

	public int nMaxDistance;

	public double dbTempThreshold;

	public double dbCorrectTemp;

	public double dbValidTempLowerLimit;

	public double dbTempRandReplaceThreshold;

	public bool bDebugModelEnable;

	public EM_THERMAL_IMAGE_CALIBRATION_MODE emCalibrationMode;

	public bool bHeatDisplayEnbale;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
