// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_MANUAL_TEST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_MANUAL_TEST_INFO
{
	public int nAction;

	public int nChannel;

	public NET_TIME_EX stuUTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAreaName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
