// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_TASK_GLOBAL_CALIBRATEAREA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_TASK_GLOBAL_CALIBRATEAREA
{
	public int nStaffs;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_STAFF_INFO[] stuStaffs;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuCalibratePloygonArea;

	public int nCalibratePloygonAreaNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
