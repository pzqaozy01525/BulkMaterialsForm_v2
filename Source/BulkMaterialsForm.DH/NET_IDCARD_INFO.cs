// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IDCARD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IDCARD_INFO
{
	public EM_IDCARD_MSG_TYPE emIDCardMsgType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCitizenName;

	public EM_CITIZENIDCARD_SEX_TYPE emSexType;

	public int nMZ;

	public NET_TIME stuBirthday;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCitizenID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szAuthority;

	public NET_TIME stuBeginValidTime;

	public NET_TIME stuEndValidTime;

	public int nEventGroupID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
