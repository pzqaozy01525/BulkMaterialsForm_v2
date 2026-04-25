// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_VEHICLE_RECOGNITION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_VEHICLE_RECOGNITION_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nVehicleAction;

	public NET_MSG_OBJECT stuObject;

	public NET_MSG_OBJECT stuVehicle;

	public NET_SEAT_INFO stuMainSeatInfo;

	public NET_SEAT_INFO stuSlaveSeatInfo;

	public int nVehicleAttachNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_VEHICLE_ATTACH[] stuVehicleAttach;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCountry;

	public int nCarCandidateNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CAR_CANDIDATE_INFO[] stuCarCandidate;

	public NET_EVENT_COMM_INFO stCommInfo;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
