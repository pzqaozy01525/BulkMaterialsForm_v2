// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AV_CFG_MonitorWall

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AV_CFG_MonitorWall
{
	public int nStructSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public int nLine;

	public int nColumn;

	public int nBlockCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_AV_CFG_MonitorWallBlock[] stuBlocks;

	public bool bDisable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDesc;
}
