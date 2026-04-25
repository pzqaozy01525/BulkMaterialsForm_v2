// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_GASSTATION_VEHICLE_DETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_GASSTATION_VEHICLE_DETECT_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public uint nRuleID;

	public EM_CLASS_TYPE emClassType;

	public NET_DETECT_VEHICLE_INFO stuDetectVehicleInfo;

	public NET_DETECT_PLATE_INFO stuDetectPlateInfo;

	public bool bIsGlobalScene;

	public NET_EVENT_PIC_INFO stuSceneImage;

	public int nCarCandidateNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CAR_CANDIDATE_INFO[] stuCarCandidate;

	public NET_FUEL_DISPENSER_INFO stuFuelDispenser;

	public NET_DEV_EVENT_TRAFFIC_TRAFFICCAR_INFO stuTrafficCar;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 872)]
	public byte[] bReserved;
}
