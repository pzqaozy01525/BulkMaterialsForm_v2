// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_INIT_DEVICE_ACCOUNT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_INIT_DEVICE_ACCOUNT
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szMac;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPwd;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCellPhone;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szMail;

	public byte byInitStatus;

	public byte byPwdResetWay;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;
}
