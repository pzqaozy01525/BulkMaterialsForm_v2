// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMAN_HELMET_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMAN_HELMET_INFO
{
	public bool bEnable;

	public bool bHasHelmet;

	public int nShowListNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_CLOTHES_COLOR[] emHumanHelmetColorShowList;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
