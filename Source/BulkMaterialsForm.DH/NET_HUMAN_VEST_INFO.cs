// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMAN_VEST_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMAN_VEST_INFO
{
	public bool bEnable;

	public int nShowListNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public EM_HUMAN_VEST_TYPE[] emHumanVestShowList;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
