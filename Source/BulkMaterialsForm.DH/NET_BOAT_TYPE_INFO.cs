// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BOAT_TYPE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BOAT_TYPE_INFO
{
	public bool bEnable;

	public int nShowListNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public EM_BOAT_TYPE[] emBoatTypeShowList;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
