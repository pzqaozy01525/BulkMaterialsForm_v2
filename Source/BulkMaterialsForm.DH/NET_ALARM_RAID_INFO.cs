// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_RAID_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_RAID_INFO
{
	public int nRaidNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_RAID_STATE_INFO[] stuRaidInfo;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string reserved;
}
