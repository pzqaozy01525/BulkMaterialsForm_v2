// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RECORD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RECORD_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;

	public int nPreRecTime;

	public bool bRedundancyEn;

	public int nStreamType;

	public int nProtocolVer;

	public bool abHolidaySchedule;

	public bool bHolidayEn;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public NET_CFG_TIME_SECTION[] stuHolTimeSection;

	public int nBackupLiveNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_BACKUP_LIVE_INFO[] stuBackupLiveInfo;

	public bool bSaveVideo;

	public bool bSaveAudio;
}
