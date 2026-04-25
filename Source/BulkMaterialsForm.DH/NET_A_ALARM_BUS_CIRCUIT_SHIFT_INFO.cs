// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_CIRCUIT_SHIFT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_CIRCUIT_SHIFT_INFO
{
	public bool bNeedConfirm;

	public uint nTime;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public NET_TIME stuTime;

	public EM_LINE_STATE emLineState;

	public bool bShiftAndPark;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	public byte[] byReserved;
}
