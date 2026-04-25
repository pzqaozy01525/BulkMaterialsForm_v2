// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMAN_DESC_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMAN_DESC_INFO
{
	public EM_HUMAN_AGE_SEG emName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public uint[] nRange;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
