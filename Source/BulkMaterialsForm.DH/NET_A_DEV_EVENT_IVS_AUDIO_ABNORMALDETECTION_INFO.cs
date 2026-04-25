// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_IVS_AUDIO_ABNORMALDETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_IVS_AUDIO_ABNORMALDETECTION_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nDecibel;

	public int nFrequency;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public uint dwSnapFlagMask;

	public NET_RESOLUTION_INFO stuResolution;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
