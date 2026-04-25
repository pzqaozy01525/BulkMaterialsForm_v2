// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TRAFFIC_FLOWSTAT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TRAFFIC_FLOWSTAT_INFO
{
	public byte abPeriod;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved1;

	public int nPeriod;

	public int nLaneNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_TRAFFIC_FLOWSTAT_INFO_LANE[] stuTrafficFlowstat;

	public uint dwLaneExtraMaxNum;

	public uint dwLaneExtraRetNum;

	public IntPtr pstuTrafficFlowstat;

	public uint nPeriodByMili;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string bReserved2;
}
