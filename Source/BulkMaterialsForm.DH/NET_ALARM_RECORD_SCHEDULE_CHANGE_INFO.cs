// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_RECORD_SCHEDULE_CHANGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_RECORD_SCHEDULE_CHANGE_INFO
{
	public int nChannelID;

	public int nEventID;

	public double dbPTS;

	public NET_TIME_EX stuTime;

	public int nEventAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUser;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
