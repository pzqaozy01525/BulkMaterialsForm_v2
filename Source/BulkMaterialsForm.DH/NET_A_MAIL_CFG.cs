// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_MAIL_CFG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_MAIL_CFG
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string sMailIPAddr;

	public ushort wMailPort;

	public ushort wReserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string sSenderAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string sUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string sUserPsw;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string sDestAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string sCcAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string sBccAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string sSubject;
}
