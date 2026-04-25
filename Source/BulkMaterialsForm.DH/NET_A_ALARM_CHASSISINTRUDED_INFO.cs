// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_ALARM_CHASSISINTRUDED_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_ALARM_CHASSISINTRUDED_INFO
{
	public uint dwSize;

	public int nAction;

	public NET_TIME stuTime;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szReaderID;

	public uint nEventID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSN;

	public bool bRealUTC;

	public NET_TIME_EX RealUTC;

	public EM_ALARM_CHASSISINTRUDED_DEV_TYPE emDevType;
}
