// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_SCADA_DEV_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_SCADA_DEV_INFO
{
	public uint dwSize;

	public int nChannel;

	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDesc;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSensorID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPointName;

	public int nAlarmFlag;

	public EM_ALARM_SCADA_DEV_TYPE emDevType;

	public EM_SCADA_DEVICE_STATUS emDevStatus;
}
