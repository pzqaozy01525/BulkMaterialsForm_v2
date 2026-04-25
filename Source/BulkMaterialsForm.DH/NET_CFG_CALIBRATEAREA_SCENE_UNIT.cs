// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_CALIBRATEAREA_SCENE_UNIT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_CALIBRATEAREA_SCENE_UNIT
{
	public uint nCalibrateAreaNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_CFG_CALIBRATEAREA_INFO[] stuCalibrateArea;
}
