// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ACCESS_CTL_BREAK_IN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ACCESS_CTL_BREAK_IN_INFO
{
	public uint dwSize;

	public int nDoor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDoorName;

	public NET_TIME stuTime;

	public uint nEventID;

	public EM_BREAK_IN_METHOD emMethod;

	public bool bRealUTC;

	public NET_TIME_EX RealUTC;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] reserved;
}
