// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_MEDIA_QUERY_FILE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_MEDIA_QUERY_FILE
{
	public uint dwSize;

	public int nChannelID;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public uint nFileSize;

	public byte byFileType;

	public byte byDriveNo;

	public byte byPartition;

	public byte byVideoStream;

	public uint nCluster;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nEventLists;

	public int nEventCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_RECORD_SNAP_FLAG_TYPE[] emFalgLists;

	public int nFalgCount;

	public uint nDriveNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szSynopsisPicPath;

	public int nSynopsisMaxTime;

	public int nSynopsisMinTime;

	public int nFileSummaryNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_FILE_SUMMARY_INFO[] stFileSummaryInfo;

	public long nFileSizeEx;

	public uint nTotalFrame;

	public EM_VIDEO_FILE_STATE emFileState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szWorkDir;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szThumbnail;

	public bool bRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;
}
