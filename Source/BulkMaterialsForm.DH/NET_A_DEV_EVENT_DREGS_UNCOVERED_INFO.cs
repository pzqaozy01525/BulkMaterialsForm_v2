// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_DREGS_UNCOVERED_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_DREGS_UNCOVERED_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double PTS;

	public NET_TIME_EX UTC;

	public uint nEventID;

	public EM_CLASS_TYPE emClassType;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	public NET_A_DREGS_UNCOVERED_VEHICLE_INFO stuVehicleInfo;

	public NET_SCENE_IMAGE_INFO stuSceneImage;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 952)]
	public byte[] byReserved;
}
