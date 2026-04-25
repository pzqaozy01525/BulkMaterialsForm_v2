// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FEATURE_VECTOR

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FEATURE_VECTOR
{
	public uint dwOffset;

	public uint dwLength;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
	public byte[] byReserved;
}
