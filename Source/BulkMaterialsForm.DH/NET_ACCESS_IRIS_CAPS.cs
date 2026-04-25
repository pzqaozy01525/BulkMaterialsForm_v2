// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_IRIS_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_IRIS_CAPS
{
	public uint nMaxInsertRate;

	public uint nMinIrisPhotoSize;

	public uint nMaxIrisPhotoSize;

	public uint nMaxIrisGroup;

	public uint nRecognitionAlgorithmVender;

	public uint nRecognitionVersion;

	public uint nMaxIrisesCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 500)]
	public byte[] byReserved;
}
