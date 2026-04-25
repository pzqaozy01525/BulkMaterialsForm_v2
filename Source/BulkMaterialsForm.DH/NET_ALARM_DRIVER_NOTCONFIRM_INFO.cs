// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_DRIVER_NOTCONFIRM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_DRIVER_NOTCONFIRM_INFO
{
	public int nAction;

	public NET_TIME_EX stuTime;

	public double dbPTS;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserver;
}
