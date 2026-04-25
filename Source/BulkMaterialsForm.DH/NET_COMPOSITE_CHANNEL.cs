// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COMPOSITE_CHANNEL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COMPOSITE_CHANNEL
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szMonitorWallName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCompositeID;

	public int nVirtualChannel;
}
