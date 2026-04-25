// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TEST_RESULT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TEST_RESULT
{
	public uint nHandValue;

	public uint nLeftFootValue;

	public uint nRightFootValue;

	public EM_ESD_RESULT emEsdResult;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] bReserved;
}
