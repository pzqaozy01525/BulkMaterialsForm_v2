// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ALARM_INFO_EX2

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ALARM_INFO_EX2
{
	public uint dwSize;

	public int nChannelID;

	public int nAction;

	public NET_TIME stuTime;

	public EM_A_NET_SENSE_METHOD emSenseType;

	public NET_MSG_HANDLE_EX stuEventHandler;

	public EM_NET_DEFENCE_AREA_TYPE emDefenceAreaType;

	public uint nEventID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szName;

	public int nCount;

	public NET_GPS_STATUS_INFO stuGPS;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public bool bExAlarmIn;

	public int nAreaNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public int[] nAreas;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 568)]
	public byte[] byReserved;
}
