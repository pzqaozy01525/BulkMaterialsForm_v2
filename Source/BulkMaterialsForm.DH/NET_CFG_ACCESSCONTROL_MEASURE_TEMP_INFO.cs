// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESSCONTROL_MEASURE_TEMP_INFO

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESSCONTROL_MEASURE_TEMP_INFO
{
	public uint dwSize;

	public bool bEnable;

	public bool bOnlyTempMode;

	public bool bDisplayTemp;

	public EM_MASK_DETECT_MODE emMaskDetectMode;

	public EM_TEMP_MEASURE_TYPE emMeasureType;

	public NET_INFRARED_MEASURE_MODE_PARAM stuInfraredTempParam;

	public NET_THERMAL_IMAGE_MEASURE_MODE_PARAM stuThermalImageTempParam;

	public NET_GUIDE_MODULE_MEASURE_MODE_PARAM stuGuideModuleTempParam;

	public NET_WRIST_MEASURE_MODE_PARAM stuWristTempParam;
}
