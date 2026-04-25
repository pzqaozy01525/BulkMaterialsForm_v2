// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ANALYSE_TASK_GLOBAL_LANES

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ANALYSE_TASK_GLOBAL_LANES
{
	public bool bEnable;

	public int nNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuLeftLinePoint;

	public int nLeftLinePointNum;

	public EM_GLOBAL_LANES_LINE_TYPE emLeftLineType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuRightLinePoint;

	public int nRightLinePointNum;

	public EM_GLOBAL_LANES_LINE_TYPE emRightLineType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
