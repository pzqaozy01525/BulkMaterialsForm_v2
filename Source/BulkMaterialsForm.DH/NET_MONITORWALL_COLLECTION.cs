// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MONITORWALL_COLLECTION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MONITORWALL_COLLECTION
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_BLOCK_COLLECTION[] stuBlocks;

	public int nBlocksCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szControlID;

	public NET_MONITORWALL stuMonitorWall;

	public EM_SAVE_COLLECTION_TYPE emType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;
}
