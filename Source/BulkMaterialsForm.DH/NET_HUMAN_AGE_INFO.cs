// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMAN_AGE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMAN_AGE_INFO
{
	public bool bEnable;

	public int nShowListNums;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public EM_HUMAN_AGE_SEG[] emHumanAgeShowList;

	public IntPtr pstuHumanDesc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
