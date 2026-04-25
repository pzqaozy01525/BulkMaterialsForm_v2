// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_LOGIN_WITH_HIGHLEVEL_SECURITY
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szIP;

	public int nPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPassword;

	public EM_LOGIN_SPAC_CAP_TYPE emSpecCap;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public IntPtr pCapParam;

	public EM_LOGIN_TLS_TYPE emTLSCap;
}
