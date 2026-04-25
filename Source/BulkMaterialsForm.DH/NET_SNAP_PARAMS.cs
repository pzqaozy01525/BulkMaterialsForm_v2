// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SNAP_PARAMS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SNAP_PARAMS
{
	public uint Channel;

	public uint Quality;

	public uint ImageSize;

	public uint mode;

	public uint InterSnap;

	public uint CmdSerial;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public uint[] Reserved;
}
