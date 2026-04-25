// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFICGLOBAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFICGLOBAL_INFO
{
	public NET_VIOLATIONCODE_INFO stViolationCode;

	public bool bEnableRedList;

	public bool abViolationTimeSchedule;

	public NET_VIOLATION_TIME_SCHEDULE stViolationTimeSchedule;

	public bool abEnableBlackList;

	public bool bEnableBlackList;

	public bool abPriority;

	public uint nPriority;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 65536)]
	public byte[] szPriority;

	public bool abNamingFormat;

	public NET_TRAFFIC_NAMING_FORMAT stNamingFormat;

	public bool abVideoNamingFormat;

	public NET_TRAFFIC_NAMING_FORMAT stVideoNamingFormat;

	public bool abCalibration;

	public NET_TRAFFIC_CALIBRATION_INFO stCalibration;

	public bool abAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAddress;

	public bool abTransferPolicy;

	public EM_TRANSFER_POLICY emTransferPolicy;

	public bool abSupportModeMaskConfig;

	public NET_TRAFFIC_EVENT_CHECK_MASK stSupportModeMaskConfig;

	public bool abIsEnableLightState;

	public NET_ENABLE_LIGHT_STATE_INFO stIsEnableLightState;

	public bool abMixModeInfo;

	public NET_MIX_MODE_CONFIG stMixModeInfo;
}
