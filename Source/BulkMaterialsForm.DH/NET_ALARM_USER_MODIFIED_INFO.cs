// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_USER_MODIFIED_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_USER_MODIFIED_INFO
{
	public int nAction;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUser;

	public EM_A_NET_EVENT_OPERATE_TYPE emOpType;

	public EM_A_NET_EVENT_USER_TYPE emUserType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
