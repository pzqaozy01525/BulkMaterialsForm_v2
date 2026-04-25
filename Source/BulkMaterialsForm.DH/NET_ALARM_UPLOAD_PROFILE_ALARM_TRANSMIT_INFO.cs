// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_UPLOAD_PROFILE_ALARM_TRANSMIT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_UPLOAD_PROFILE_ALARM_TRANSMIT_INFO
{
	public uint dwSize;

	public int nAction;

	public NET_TIME_EX stuTime;

	public uint nRealUTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public EM_SENSE_METHOD emSenseMethod;

	public EM_PROFILE_ALARM_TRANSMIT_DEVSRC_TYPE emDevSrcType;

	public EM_PROFILE_ALARM_TRANSMIT_ALARM_TYPE emAlarmType;

	public NET_PROFILE_ALARM_TRANSMIT_ALARM_INFO stuAlarmInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSnapURL;
}
