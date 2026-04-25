// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AV_CFG_MonitorWallBlock

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AV_CFG_MonitorWallBlock
{
	public int nStructSize;

	public int nLine;

	public int nColumn;

	public NET_AV_CFG_Rect stuRect;

	public int nTVCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_AV_CFG_MonitorWallTVOut[] stuTVs;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 42)]
	public NET_CFG_TIME_SECTION[] stuTimeSection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCompositeID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBlockType;

	public int nOutputDelay;
}
