// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ANATOMY_TEMP_DETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ANATOMY_TEMP_DETECT_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleName;

	public bool bRuleEnable;

	public int nObjectTypeNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szObjectTypes;

	public int nPtzPresetId;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;

	public byte bTrackEnable;

	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuDetectRegion;

	public bool bHighEnable;

	public bool bLowEnable;

	public int fHighThresholdTemp;

	public int fLowThresholdTemp;

	public bool bIsAutoStudy;

	public int fHighAutoOffset;

	public int fLowAutoOffset;

	public int nSensitivity;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO_EX stuSizeFileter;

	public bool bIsCaptureNormal;

	public NET_A_HUMAN_TEMP_PARAM_INFO stuHumanTempParamInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 768)]
	public byte[] byReserved;
}
