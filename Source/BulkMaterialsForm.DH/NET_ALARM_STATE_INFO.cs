// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_STATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_STATE_INFO
{
	public int nAlarmCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nAlarmState;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byRserved;
}
