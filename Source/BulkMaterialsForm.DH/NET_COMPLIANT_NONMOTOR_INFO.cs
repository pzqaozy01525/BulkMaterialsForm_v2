// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_COMPLIANT_NONMOTOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_COMPLIANT_NONMOTOR_INFO
{
	public NET_NONMOTOR_COLOR_INFO stuNonMotorColor;

	public NET_NONMOTOR_CYCLING_NUM_INFO stuNumOfCycling;

	public NET_NONMOTOR_CATEGORY_INFO stuCategory;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szReserved;
}
