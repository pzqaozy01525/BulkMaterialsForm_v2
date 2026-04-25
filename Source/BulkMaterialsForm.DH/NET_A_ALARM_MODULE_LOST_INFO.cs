// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_MODULE_LOST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_MODULE_LOST_INFO
{
	public uint dwSize;

	public NET_TIME stuTime;

	public int nSequence;

	public EM_A_NET_BUS_TYPE emBusType;

	public int nAddr;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] anAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevType;

	public bool bOnline;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;
}
