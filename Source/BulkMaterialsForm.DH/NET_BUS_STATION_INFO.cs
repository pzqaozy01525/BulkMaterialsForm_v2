// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BUS_STATION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BUS_STATION_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szBusNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szParkPosition;

	public EM_ALCOHOL_STATE emAlcoholState;

	public EM_BUS_REPAIR_STATE emRepairState;

	public EM_BUS_OIL_STATE emOilState;

	public EM_BUS_WASH_STATE emWashState;

	public EM_BUS_CASH_STATE emCashState;

	public EM_SCHEDULE_STATE emScheduleState;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
