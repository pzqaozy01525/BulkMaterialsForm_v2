// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_ACCESSORY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_ACCESSORY_INFO
{
	public uint dwSize;

	public bool bRecordEnable;

	public bool bExternalAlarmEnable;

	public bool bArmingWithoutPassword;

	public byte byAlarmLedIndication;

	public byte byExPowerCheck;

	public byte byTamper;

	public byte by24HDefenceStatus;

	public byte byAlarmStatus;

	public byte byExternalAlarmStatus;

	public byte byLedIndication;

	public byte byBeepIndication;

	public byte bySosStatus;

	public byte byViaTrace;

	public byte bySensorType;

	public byte byLockState;

	public byte bySensorFailure;

	public byte bySignalStrengthTest;

	public byte bySensitivityTest;

	public byte byVolumeTest;

	public byte bySnapshotTest;

	public byte byWifiTest;

	public byte byBlockState;

	public uint nShortAddr;

	public uint nPercent;

	public uint nSignalLevel;

	public uint nEntryDelay;

	public uint nExitDelay;

	public uint nAlarmDuring;

	public int nTriggerAlarmInterval;

	public EM_DETECTOR_STATUS_TYPE emState;

	public EM_ACCESSORY_VOLUME emBeepVolume;

	public EM_ACCESSORY_SENSITIVITY emSensentivity;

	public EM_POWER_REGULATION_TYPE emPowerRegulation;

	public EM_ONLINE_STATUS emOnline;

	public EM_ACCESSORY_ALARM_TYPE emAlarmType;

	public EM_ACCESSORY_INPUT_TYPE emInputType;

	public EM_LED_BRIGHTNESS_LEVEL emLedBrightnessLevel;

	public EM_OPERATION_MODE emOperationMode;

	public EM_ANTI_MISPRESS_TYPE emAntiMispress;

	public EM_EXPOWER_STATE emExPowerState;

	public EM_ACCESSORY_VOLUME emVolume;

	public float fAmbientTemperature;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szModel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAlarmTone;

	public NET_WPAN_RELAY_INFO stuRelayTran;

	public EM_A_NET_SENSE_METHOD emType;

	public NET_WPAN_HEARTBEAT_INFO stuHeartbeat;

	public NET_WPAN_ACCESSORY_CAPS_INFO stuCaps;

	public NET_WPAN_ACCESSORY_LOCK_INFO stuLockInfo;

	public NET_WPAN_CARD_READER_INFO stuCardReader;

	public NET_WPAN_ACCESSORY_IMAGE_INFO stuImageInfo;

	public NET_WPAN_EXTERNAL_WIFI_INFO stuExternalWifi;

	public NET_WPAN_WIFI_INFO stuWifiInfo;

	public NET_WPAN_OVER_TEMPERATURE_ALARM_INFO stuOverTemperatureAlarm;

	public uint nAreaNumberCnt;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public int[] nAreaNumber;

	public uint nControlAreaNumCnt;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public int[] nControlAreaNum;

	public uint nRecordChannelsNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nRecordChannels;

	public uint nSirenLinkageNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nSirenLinkage;

	public uint nArmingInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_WPAN_ARMING_INFO[] stuArmingInfo;

	public uint nButtonNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_WPAN_ACCESSORY_BUTTON_INFO[] stuButton;
}
