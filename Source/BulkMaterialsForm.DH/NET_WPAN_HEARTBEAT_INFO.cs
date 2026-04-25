// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WPAN_HEARTBEAT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WPAN_HEARTBEAT_INFO
{
	public uint nInterval;

	public uint nOfflineTimes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] byReserved;
}
