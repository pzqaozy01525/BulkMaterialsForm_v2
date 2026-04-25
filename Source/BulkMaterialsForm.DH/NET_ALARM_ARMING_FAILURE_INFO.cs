// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_ARMING_FAILURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_ARMING_FAILURE_INFO
{
	public int nAction;

	public int nChannel;

	public NET_TIME_EX stuUTC;

	public EM_ARM_TYPE emMode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
