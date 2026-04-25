// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AV_CFG_EventHandler

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AV_CFG_EventHandler
{
	public int nStructSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
	public NET_AV_CFG_TimeSection[] stuTimeSect;

	public bool bRecordEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public uint[] nRecordMask;

	public bool abRecordLatch;

	public int nRecordLatch;

	public bool bAlarmOutEn;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public uint[] nAlarmOutMask;

	public bool abAlarmOutLatch;

	public int nAlarmOutLatch;

	public bool bExAlarmOutEn;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public uint[] nExAlarmOutMask;

	public bool bPtzLinkEn;

	public int nPtzLinkNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public NET_AV_CFG_PtzLink[] stuPtzLink;

	public bool bSnapshotEn;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public uint[] nSnapshotMask;

	public bool abSnapshotPeriod;

	public int nSnapshotPeriod;

	public bool abSnapshotTimes;

	public int nSnapshotTimes;

	public bool bSnapshotTitleEn;

	public int nSnapTitleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_AV_CFG_EventTitle[] stuSnapTitles;

	public bool bTipEnable;

	public bool bMailEnable;

	public bool bMessageEnable;

	public bool bBeepEnable;

	public bool bVoiceEnable;

	public bool abDejitter;

	public int nDejitter;

	public bool bLogEnable;

	public bool abDelay;

	public int nDelay;

	public bool bVideoTitleEn;

	public int nVideoTitleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_AV_CFG_EventTitle[] stuVideoTitles;

	public bool bMMSEnable;

	public int nTourNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_AV_CFG_TourLink[] stuTour;

	public int nDBKeysNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szDBKeys;

	public bool abJpegSummary;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byJpegSummary;
}
