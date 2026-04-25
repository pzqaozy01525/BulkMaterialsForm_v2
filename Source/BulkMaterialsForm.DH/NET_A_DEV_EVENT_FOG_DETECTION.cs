// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_FOG_DETECTION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_FOG_DETECTION
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public EM_CLASS_TYPE emClassType;

	public int nGroupID;

	public int nCountInGroup;

	public int nIndexInGroup;

	public int nPresetID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPresetName;

	public EM_FOG_DETECTION_EVENT_TYPE emEventType;

	public NET_A_FOG_DETECTION_FOG_INFO stuFogInfo;

	public NET_EVENT_FILE_INFO stFileInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
