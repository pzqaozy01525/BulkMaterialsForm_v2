// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_NTP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_NTP_INFO
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szAddress;

	public int nPort;

	public int nUpdatePeriod;

	public EM_CFG_TIME_ZONE_TYPE emTimeZoneType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szTimeZoneDesc;

	public int nSandbyServerNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public CFG_NTP_SERVER[] stuStandbyServer;

	public int nTolerance;
}
