// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_TRAFFIC_CAR_MEASUREMENT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_TRAFFIC_CAR_MEASUREMENT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public uint nEventID;

	public uint nSpeed;

	public EM_TRIGGER_TYPE emTriggerType;

	public EM_TRIGGER_OCCUR_TYPE emTriggerOccur;

	public uint nMark;

	public uint nSource;

	public uint nFrameSequence;

	public int nLaneID;

	public NET_TIME_EX stuRedLightStartTime;

	public EM_CAPTURE_PROCESS_END_TYPE emCaptureProcess;

	public NET_EVENT_CARD_INFO stuCardInfo;

	public EM_VEHICLE_DRIVING_DIRECTION emDrivingDirection;

	public EM_TRFAFFIC_LIGHT_TYPE emLightState;

	public EM_OPEN_STROBE_STATE emOpenStrobeState;

	public EM_VEHICLE_DIRECTION emVehicleDirection;

	public EM_SAFEBELT_STATE emMainSeat;

	public EM_SAFEBELT_STATE emSlaveSeat;

	public NET_EVENT_PLATE_INFO stuPlateInfo;

	public NET_CAR_WEIGHT_INFO stuCarWeightInfo;

	public NET_RADAR_REPORTS_VEHICLE_INFO stuRadarReportsVehicleInfo;

	public NET_EVENT_COMM_INFO stuCommInfo;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stTrafficCar;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
