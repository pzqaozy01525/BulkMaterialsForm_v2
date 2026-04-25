// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_FACEANALYSIS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_FACEANALYSIS_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleName;

	public byte bRuleEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved;

	public int nObjectTypeNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szObjectTypes;

	public int nDetectRegionPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_CFG_POLYGON[] stuDetectRegion;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;

	public int nPtzPresetId;

	public int nSensitivity;

	public int nLinkGroupNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_A_CFG_LINKGROUP_INFO[] stuLinkGroup;

	public NET_CFG_STRANGERMODE_INFO stuStrangerMode;

	public bool bSizeFileter;

	public NET_CFG_SIZEFILTER_INFO_EX stuSizeFileter;

	public bool bFeatureEnable;

	public int nFaceFeatureNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_FACEFEATURE_TYPE[] emFaceFeatureType;

	public bool bFeatureFilter;

	public int nMinQuality;
}
