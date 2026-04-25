// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_NTP_CFG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_NTP_CFG
{
	public bool bEnable;

	public int nHostPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szHostIp;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDomainName;

	public int nType;

	public int nUpdateInterval;

	public EM_TIME_ZONE_TYPE emTimeZone;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] reserved;
}
