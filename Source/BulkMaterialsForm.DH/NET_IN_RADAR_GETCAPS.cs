// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_RADAR_GETCAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_RADAR_GETCAPS
{
	public uint dwSize;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRadarIP;
}
