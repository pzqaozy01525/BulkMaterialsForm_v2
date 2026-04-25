// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_FEATURE_VECTOR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_FEATURE_VECTOR_INFO
{
	public uint nOffset;

	public uint nLength;

	public bool bFeatureEnc;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
	public byte[] byReserved;
}
