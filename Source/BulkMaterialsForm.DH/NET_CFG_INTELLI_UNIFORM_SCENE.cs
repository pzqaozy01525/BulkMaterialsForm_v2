// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_INTELLI_UNIFORM_SCENE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_INTELLI_UNIFORM_SCENE
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szSubType;

	public int nPlateHintNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szPlateHints;

	public int nLaneNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_LANE[] stuLanes;
}
