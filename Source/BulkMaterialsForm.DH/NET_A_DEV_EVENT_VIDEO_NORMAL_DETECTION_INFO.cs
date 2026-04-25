// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_VIDEO_NORMAL_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_VIDEO_NORMAL_DETECTION_INFO
{
	public int nChannelID;

	public int nAction;

	public uint nEventID;

	public NET_TIME_EX UTC;

	public double dbPTS;

	public EM_VIDEO_ABNORMAL_DETECT_TYPE emDetectType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	public byte[] bReserved;
}
