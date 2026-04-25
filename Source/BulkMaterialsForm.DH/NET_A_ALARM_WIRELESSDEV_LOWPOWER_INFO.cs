// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_WIRELESSDEV_LOWPOWER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_WIRELESSDEV_LOWPOWER_INFO
{
	public EM_A_NET_THREE_STATUS_BOOL emResult;

	public NET_TIME stuTime;

	public int nId;

	public EM_A_NET_WIRELESSDEV_LOWPOWER_TYPE emType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public float fPercent;

	public int nIndex;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 984)]
	public byte[] reserved;
}
