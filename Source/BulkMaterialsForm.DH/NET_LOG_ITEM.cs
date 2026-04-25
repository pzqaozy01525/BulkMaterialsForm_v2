// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_LOG_ITEM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_LOG_ITEM
{
	public NETDEVTIME time;

	public ushort type;

	public byte reserved;

	public byte data;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] context;
}
