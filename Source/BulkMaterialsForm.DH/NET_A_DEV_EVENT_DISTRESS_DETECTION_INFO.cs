// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_DISTRESS_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_DISTRESS_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public EM_CLASS_TYPE emClassType;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public uint nSequence;

	public uint nRuleID;

	public NET_MSG_OBJECT stuObject;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public int nDetectRegionNum;

	public uint nPresetID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
