// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_IPC_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_IPC_INFO
{
	public uint dwSize;

	public int nChannelID;

	public int nEventAction;

	public NET_TIME_EX UTC;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public int nAlarmChannel;
}
