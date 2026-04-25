// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FIND_NET_RECORD_ACCESS_ALARMRECORD_INFO_CONDITION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FIND_NET_RECORD_ACCESS_ALARMRECORD_INFO_CONDITION
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserID;

	public NET_TIME stStartTime;

	public NET_TIME stEndTime;
}
