// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ISCSI_TARGET

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ISCSI_TARGET
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUser;

	public int nPort;

	public uint nStatus;
}
