// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_NTP_CHANGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_NTP_CHANGE_INFO
{
	public int nEventID;

	public int nEventAction;

	public double dbPTS;

	public NET_TIME_EX stuTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUser;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1028)]
	public byte[] byReserved;
}
