// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_TRAFFIC_SNAP_STROBE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_TRAFFIC_SNAP_STROBE_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSerialNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVendor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevType;

	public EM_TRAFFIC_SNAP_DEVICE_WORK_STATE emWorkState;

	public EM_TRAFFIC_SNAP_STROBE_FAULT_CODE_TYPE emFaultCode;

	public uint nOpenStrobeCount;

	public EM_TRAFFIC_SNAP_STROBE_RUN_STATE emRunState;

	public EM_TRAFFIC_SNAP_STROBE_ACTION_REASON_TYPE emStrobeActionReason;

	public EM_RELAY_STATE_TYPE emHeavyCurrentRelayState;

	public EM_RELAY_STATE_TYPE emSignalRelay1State;

	public EM_RELAY_STATE_TYPE emSignalRelay2State;

	public EM_TRAFFIC_SNAP_GROUND_SENSE_IN_STATE_TYPE emGroundSenseInState;

	public EM_TRAFFIC_SNAP_STROBE_IN_STATE_TYPE emStrobeInPutState;

	public EM_TRAFFIC_SNAP_STROBE_RAIL_STATE_TYPE emRailState;

	public uint nCommPort;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
