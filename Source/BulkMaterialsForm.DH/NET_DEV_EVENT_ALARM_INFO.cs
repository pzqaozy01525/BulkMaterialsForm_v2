// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_ALARM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_ALARM_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string Reserved;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public NET_EVENT_COMM_INFO stCommInfo;

	public byte byEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] byReserved;

	public EM_A_NET_SENSE_METHOD emSenseType;

	public EM_NET_DEFENCE_AREA_TYPE emDefenceAreaType;

	public NET_GPS_STATUS_INFO stuGPS;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public bool bExAlarmIn;

	public NET_FILE_PROCESS_INFO stuFileProcessInfo;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szReserved;
}
