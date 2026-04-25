// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_REMOTE_FILE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_REMOTE_FILE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPath;

	public uint nSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
	public byte[] byReserved;
}
