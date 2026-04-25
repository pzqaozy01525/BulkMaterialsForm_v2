// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCREEEN_BACKGROUD

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCREEEN_BACKGROUD
{
	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 130)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 130)]
	public byte[] byReserved;
}
