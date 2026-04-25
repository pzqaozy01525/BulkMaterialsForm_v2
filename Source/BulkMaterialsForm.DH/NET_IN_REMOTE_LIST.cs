// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_REMOTE_LIST

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_REMOTE_LIST
{
	public uint dwSize;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPath;
}
