// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_MANUAL_SNAP

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_MANUAL_SNAP
{
	public uint dwSize;

	public uint nChannel;

	public uint nCmdSerial;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;
}
