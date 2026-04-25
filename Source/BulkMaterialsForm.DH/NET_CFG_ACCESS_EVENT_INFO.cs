// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ACCESS_EVENT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ACCESS_EVENT_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szChannelName;

	public EM_CFG_ACCESS_STATE emState;

	public EM_CFG_ACCESS_MODE emMode;

	public int nEnableMode;

	public bool bSnapshotEnable;

	public byte abDoorOpenMethod;

	public byte abUnlockHoldInterval;

	public byte abCloseTimeout;

	public byte abOpenAlwaysTimeIndex;

	public byte abCloseAlwaysTimeIndex;

	public byte abHolidayTimeIndex;

	public byte abBreakInAlarmEnable;

	public byte abRepeatEnterAlarmEnable;

	public byte abDoorNotClosedAlarmEnable;

	public byte abDuressAlarmEnable;

	public byte abDoorTimeSection;

	public byte abSensorEnable;

	public byte abFirstEnterEnable;

	public byte abRemoteCheck;

	public byte abRemoteDetail;

	public byte abHandicapTimeOut;

	public byte abCheckCloseSensor;

	public byte abAutoRemoteCheck;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] reverse;

	public EM_CFG_DOOR_OPEN_METHOD emDoorOpenMethod;

	public int nUnlockHoldInterval;

	public int nCloseTimeout;

	public int nOpenAlwaysTimeIndex;

	public int nCloseAlwaysTimeIndex;

	public int nHolidayTimeRecoNo;

	public bool bBreakInAlarmEnable;

	public bool bRepeatEnterAlarm;

	public bool bDoorNotClosedAlarmEnable;

	public bool bDuressAlarmEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
	public NET_CFG_DOOROPEN_TIMESECTION_INFO[] stuDoorTimeSection;

	public bool bSensorEnable;

	public NET_CFG_ACCESS_FIRSTENTER_INFO stuFirstEnterInfo;

	public bool bRemoteCheck;

	public NET_CFG_REMOTE_DETAIL_INFO stuRemoteDetail;

	public NET_CFG_HANDICAP_TIMEOUT_INFO stuHandicapTimeOut;

	public bool bCloseCheckSensor;

	public NET_CFG_AUTO_REMOTE_CHECK_INFO stuAutoRemoteCheck;

	public bool bLocalControlEnable;

	public bool bRemoteControlEnable;

	public int nSensorDelay;

	public int nHumanStatusSensitivity;

	public int nDetectSensitivity;

	public bool bLockTongueEnable;

	public int nABLockRoute;

	public int nDoorNotClosedReaderAlarmTime;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public int nCloseDuration;

	public int nUnlockReloadInterval;

	public EM_CFG_ACCESS_PROTOCOL emAccessProtocol;

	public EM_CFG_SERIAL_PROTOCOL_TYPE emProtocolType;

	public NET_CFG_ACCESS_CONTROL_UDP_INFO stuAccessControlUdpInfo;

	public uint nEntranceLockChannel;

	public bool bSnapshotUpload;

	public uint nSnapUploadPos;

	public bool bCustomPasswordEnable;

	public int nRepeatEnterTime;

	public int nCardNoConvert;

	public bool bUnAuthorizedMaliciousSwipEnable;

	public bool bFakeLockedAlarmEnable;

	public EM_CFG_CARD_STATE emReadCardState;

	public bool bHelmetEnable;

	public uint nSpecialDaysOpenAlwaysTime;

	public uint nSpecialDaysCloseAlwaysTime;
}
