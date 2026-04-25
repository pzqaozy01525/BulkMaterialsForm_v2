// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_TAGMANAGER_STARTTAG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_TAGMANAGER_STARTTAG_INFO
{
	public uint dwSize;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szContext;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szContextEx;

	public byte bIsUsingContextEx;
}
