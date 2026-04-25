// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_MAIL_CFG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_MAIL_CFG
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string sMailIPAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string sSubMailIPAddr;

	public ushort wMailPort;

	public ushort wSubMailPort;

	public ushort wReserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string sSenderAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string sUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string sUserPsw;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string sDestAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string sCcAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string sBccAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string sSubject;

	public byte bEnable;

	public byte bSSLEnable;

	public ushort wSendInterval;

	public byte bAnonymous;

	public byte bAttachEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 154)]
	public string reserved;
}
