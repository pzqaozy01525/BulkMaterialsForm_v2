// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_TASK_GLOBAL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_TASK_GLOBAL
{
	public int nLanesNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_ANALYSE_TASK_GLOBAL_LANES[] stuLanes;

	public int nCalibrateArea;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_ANALYSE_TASK_GLOBAL_CALIBRATEAREA[] stuCalibrateArea;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
