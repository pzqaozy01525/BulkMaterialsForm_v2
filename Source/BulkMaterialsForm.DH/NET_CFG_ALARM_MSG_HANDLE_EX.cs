// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ALARM_MSG_HANDLE_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ALARM_MSG_HANDLE_EX
{
	public byte abRecordMask;

	public byte abRecordEnable;

	public byte abRecordLatch;

	public byte abAlarmOutMask;

	public byte abAlarmOutEn;

	public byte abAlarmOutLatch;

	public byte abExAlarmOutMask;

	public byte abExAlarmOutEn;

	public byte abPtzLinkEn;

	public byte abTourMask;

	public byte abTourEnable;

	public byte abSnapshot;

	public byte abSnapshotEn;

	public byte abSnapshotPeriod;

	public byte abSnapshotTimes;

	public byte abTipEnable;

	public byte abMailEnable;

	public byte abMessageEnable;

	public byte abBeepEnable;

	public byte abVoiceEnable;

	public byte abMatrixMask;

	public byte abMatrixEnable;

	public byte abEventLatch;

	public byte abLogEnable;

	public byte abDelay;

	public byte abVideoMessageEn;

	public byte abMMSEnable;

	public byte abMessageToNetEn;

	public byte abTourSplit;

	public byte abSnapshotTitleEn;

	public byte abChannelCount;

	public byte abAlarmOutCount;

	public byte abPtzLinkEx;

	public byte abSnapshotTitle;

	public byte abMailDetail;

	public byte abVideoTitleEn;

	public byte abVideoTitle;

	public byte abTour;

	public byte abDBKeys;

	public byte abJpegSummary;

	public byte abFlashEn;

	public byte abFlashLatch;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved1;

	public int nChannelCount;

	public int nAlarmOutCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public uint[] dwRecordMask;

	public bool bRecordEnable;

	public int nRecordLatch;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public uint[] dwAlarmOutMask;

	public bool bAlarmOutEn;

	public int nAlarmOutLatch;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public uint[] dwExAlarmOutMask;

	public bool bExAlarmOutEn;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_CFG_PTZ_LINK[] stuPtzLink;

	public bool bPtzLinkEn;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public uint[] dwTourMask;

	public bool bTourEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public uint[] dwSnapshot;

	public bool bSnapshotEn;

	public int nSnapshotPeriod;

	public int nSnapshotTimes;

	public bool bTipEnable;

	public bool bMailEnable;

	public bool bMessageEnable;

	public bool bBeepEnable;

	public bool bVoiceEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public uint[] dwMatrixMask;

	public bool bMatrixEnable;

	public int nEventLatch;

	public bool bLogEnable;

	public int nDelay;

	public bool bVideoMessageEn;

	public bool bMMSEnable;

	public bool bMessageToNetEn;

	public int nTourSplit;

	public bool bSnapshotTitleEn;

	public int nPtzLinkExNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_CFG_PTZ_LINK_EX[] stuPtzLinkEx;

	public int nSnapTitleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_CFG_EVENT_TITLE_NEW[] stuSnapshotTitle;

	public NET_CFG_MAIL_DETAIL stuMailDetail;

	public bool bVideoTitleEn;

	public int nVideoTitleNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_CFG_EVENT_TITLE_NEW[] stuVideoTitle;

	public int nTourNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_CFG_TOURLINK[] stuTour;

	public int nDBKeysNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
	public string szDBKeys;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byJpegSummary;

	public bool bFlashEnable;

	public int nFlashLatch;

	public byte abAudioFileName;

	public byte abAlarmBellEn;

	public byte abAccessControlEn;

	public byte abAccessControl;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szAudioFileName;

	public bool bAlarmBellEn;

	public bool bAccessControlEn;

	public uint dwAccessControl;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public EM_CFG_ACCESSCONTROLTYPE[] emAccessControlType;

	public byte abTalkBack;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved2;

	public NET_CFG_TALKBACK_INFO stuTalkback;

	public byte abPSTNAlarmServer;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved3;

	public NET_CFG_PSTN_ALARM_SERVER stuPSTNAlarmServer;

	public NET_CFG_TIME_SCHEDULE stuTimeSection;

	public byte abAlarmBellLatch;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved4;

	public int nAlarmBellLatch;

	public byte abAudioPlayTimes;

	public byte abAudioLinkTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved5;

	public uint nAudioPlayTimes;

	public uint nAudioLinkTime;

	public byte abAlarmOutTime;

	public int nAlarmOutTime;

	public byte abBeepTime;

	public int nBeepTime;
}
