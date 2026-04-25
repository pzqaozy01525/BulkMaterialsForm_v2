// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ADD_BYGROUP_RESULT_CAMERA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ADD_BYGROUP_RESULT_CAMERA
{
	public uint nUniqueChannel;

	public uint nFailedCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
