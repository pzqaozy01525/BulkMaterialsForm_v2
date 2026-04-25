// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CASCADE_AUTHENTICATOR

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CASCADE_AUTHENTICATOR
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUser;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPwd;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szSerialNo;
}
