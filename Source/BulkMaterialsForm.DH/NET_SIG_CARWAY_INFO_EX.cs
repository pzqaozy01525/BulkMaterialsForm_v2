// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SIG_CARWAY_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SIG_CARWAY_INFO_EX
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] byRedundance;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
	public byte[] bReserved;
}
