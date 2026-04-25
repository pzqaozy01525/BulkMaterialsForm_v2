// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ATTENDANCE_USERINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ATTENDANCE_USERINFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 36)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	public EM_ATTENDANCE_AUTHORITY emAuthority;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPassword;

	public int nPhotoLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szClassNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPhoneNumber;

	public EM_A_NET_ACCESSCTLCARD_TYPE emCardType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 204)]
	public byte[] byReserved;
}
