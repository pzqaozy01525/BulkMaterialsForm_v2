// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_NONMOTOR_COLOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_NONMOTOR_COLOR_INFO
{
	public bool bEnable;

	public int nShowListNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_OBJECT_COLOR_TYPE[] emNonMotorColorShowList;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
