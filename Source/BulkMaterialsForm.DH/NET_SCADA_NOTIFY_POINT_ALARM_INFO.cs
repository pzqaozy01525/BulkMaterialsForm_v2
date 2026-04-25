// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCADA_NOTIFY_POINT_ALARM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCADA_NOTIFY_POINT_ALARM_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDevID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPointID;

	public bool bAlarmFlag;

	public NET_TIME stuAlarmTime;

	public int nAlarmLevel;

	public int nSerialNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAlarmDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSignalName;
}
