// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFICCAR_BLACK_LIST

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFICCAR_BLACK_LIST
{
	public bool bEnable;

	public bool bIsBlackCar;

	public NET_TIME stuBeginTime;

	public NET_TIME stuCancelTime;

	public EM_NET_TRAFFIC_CAR_CONTROL_TYPE emControlType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
	public byte[] bReserved;
}
