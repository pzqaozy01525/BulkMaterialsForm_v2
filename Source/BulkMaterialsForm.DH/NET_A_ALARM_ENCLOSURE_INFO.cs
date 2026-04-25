// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_ENCLOSURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_ENCLOSURE_INFO
{
	public int nTypeNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] bType;

	public int nAlarmTypeNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] bAlarmType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDriverId;

	public uint unEnclosureId;

	public uint unLimitSpeed;

	public uint unCurrentSpeed;

	public NET_TIME stAlarmTime;

	public uint dwLongitude;

	public uint dwLatidude;

	public byte bOffline;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
	public string reserve;

	public uint unTriggerCount;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
