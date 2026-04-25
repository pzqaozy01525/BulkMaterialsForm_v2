// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ENCODE_CHANNELTITLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ENCODE_CHANNELTITLE_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szChannelName;
}
