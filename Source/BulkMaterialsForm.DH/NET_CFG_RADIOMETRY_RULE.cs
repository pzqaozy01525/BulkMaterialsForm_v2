// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RADIOMETRY_RULE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RADIOMETRY_RULE
{
	public bool bEnable;

	public int nPresetId;

	public int nRuleId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public EM_RADIOMETRY_METERTYPE nMeterType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_CFG_POLYGON[] stCoordinates;

	public int nCoordinateCnt;

	public int nSamplePeriod;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_CFG_RADIOMETRY_ALARMSETTING[] stAlarmSetting;

	public int nAlarmSettingCnt;

	public NET_CFG_RADIOMETRY_LOCALPARAM stLocalParameters;

	public EM_CFG_AREA_SUBTYPE emAreaSubType;
}
