// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_BUS_EXPORT_SITE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_BUS_EXPORT_SITE_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSiteID;

	public uint dwSiteNum;

	public EM_A_NET_LINE_DIRECTION emDirection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szLineID;

	public NET_TIME_EX stuTime;

	public int nTime;

	public EM_A_NET_BUS_STATE emState;

	public EM_A_NET_PORT_TYPE emType;

	public NET_GPS_STATUS_INFO stuGPSStatusInfo;

	public uint dwSiteCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSiteName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDesignation;

	public EM_VEHICLE_DATA_TYPE emDataType;

	public bool bNeedConfirm;

	public uint nFromMileage;

	public uint nTotalMileage;

	public uint nFromCostTime;

	public uint nTotalCostTime;

	public int nCurrentPeople;

	public uint nTotalIn;

	public uint nTotalOut;

	public uint nSubtotalCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_SUBTOTAL[] stuSubtotal;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szScheduleUniqueId;
}
