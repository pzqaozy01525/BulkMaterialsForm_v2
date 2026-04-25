// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_CUR_OIL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_CUR_OIL_INFO
{
	public uint dwSize;

	public bool bNeedConfirm;

	public int nTime;

	public EM_VEHICLE_DATA_TYPE emDataType;

	public NET_TIME stuTime;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public NET_TIME stuStartTime;

	public NET_GPS_STATUS_INFO stuStartGPSStatusInfo;

	public uint nCurOil;

	public uint nOilTankage;

	public int nOilChange;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCarNO;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_SUB_OIL_LIST_INFO[] stuSubOilList;

	public int nSubOilNum;
}
