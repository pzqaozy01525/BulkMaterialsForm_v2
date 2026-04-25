// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_FACERECOGNITION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_FACERECOGNITION_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleName;

	public byte bRuleEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved;

	public int nObjectTypeNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szObjectTypes;

	public int nPtzPresetId;

	public byte bySimilarity;

	public byte byAccuracy;

	public byte byMode;

	public byte byImportantRank;

	public int nAreaNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] byAreas;

	public int nMaxCandidate;

	public NET_CFG_ALARM_MSG_HANDLE_EX stuEventHandler;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 70)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;
}
