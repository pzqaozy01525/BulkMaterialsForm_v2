// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_STEAL_OIL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_STEAL_OIL_INFO
{
	public uint dwSize;

	public bool bNeedConfirm;

	public int nTime;

	public EM_VEHICLE_DATA_TYPE emDataType;

	public NET_TIME stuTime;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public uint nCurOil;

	public uint nOilTankage;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCarNO;
}
