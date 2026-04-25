// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_ROUTE_OVERTIME_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_ROUTE_OVERTIME_INFO
{
	public bool bNeedConfirm;

	public uint nTime;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
