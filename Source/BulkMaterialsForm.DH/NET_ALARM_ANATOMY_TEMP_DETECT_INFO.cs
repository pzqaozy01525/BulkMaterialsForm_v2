// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ANATOMY_TEMP_DETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ANATOMY_TEMP_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public uint nPresetID;

	public NET_MAN_TEMP_INFO stManTempInfo;

	public uint nSequence;

	public uint nEventRelevanceID;

	public bool bIsFaceRecognition;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
