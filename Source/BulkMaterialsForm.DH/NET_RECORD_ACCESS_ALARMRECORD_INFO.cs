// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORD_ACCESS_ALARMRECORD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORD_ACCESS_ALARMRECORD_INFO
{
	public uint dwSize;

	public int nRecNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserID;

	public EM_RECORD_ACCESS_ALARM_TYPE emAlarmType;

	public int nDevAddress;

	public int nChannel;

	public EM_RECORD_ACCESS_ALARM_OPEN_METHOD emAlarmOpenMethod;

	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szReaderID;
}
