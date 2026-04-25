// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_DEFENSE_CHANGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_DEFENSE_CHANGE_INFO
{
	public int nChannelID;

	public int nAction;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szClass;

	public double dbPTS;

	public NET_TIME_EX stuUTC;

	public int nEventID;

	public int nDefenseStateNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_DEFENSE_STATE[] stuDefenseState;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
