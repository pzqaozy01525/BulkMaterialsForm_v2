// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_FACE_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_FACE_CAPS
{
	public int nMaxInsertRate;

	public int nMaxFace;

	public int nRecognitionType;

	public int nRecognitionAlgorithm;

	public uint dwRecognitionVersion;

	public int nMinPhotoSize;

	public int nMaxPhotoSize;

	public int nMaxGetPhotoNumber;

	public bool bIsSupportGetPhoto;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 504)]
	public byte[] byReserved;
}
