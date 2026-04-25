// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_WANDER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_WANDER_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public byte byImageIndex;

	public int nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_MSG_OBJECT[] stuObjectIDs;

	public int nTrackNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_POLY_POINTS[] stuTrackInfo;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	public uint dwSnapFlagMask;

	public int nSourceIndex;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szSourceDevice;

	public uint nOccurrenceCount;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public short nPreserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPresetName;

	public NET_EXTENSION_INFO stuExtensionInfo;

	public NET_POSTION stuPostion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string byReserved2;

	public uint nCurChannelHFOV;

	public uint nCurChannelVFOV;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 402)]
	public byte[] szReserved;
}
