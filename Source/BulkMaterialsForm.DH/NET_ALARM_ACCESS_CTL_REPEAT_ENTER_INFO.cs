// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ACCESS_CTL_REPEAT_ENTER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ACCESS_CTL_REPEAT_ENTER_INFO
{
	public uint dwSize;

	public int nDoor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDoorName;

	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	public uint nEventID;
}
