// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_SENSOR_ABNORMAL_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_SENSOR_ABNORMAL_INFO
{
	public int nAction;

	public int nChannelID;

	public NET_TIME_EX stuTime;

	public EM_SENSOR_ABNORMAL_STATUS emStatus;

	public EM_A_NET_SENSE_METHOD emSenseMethod;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] byReserved;
}
