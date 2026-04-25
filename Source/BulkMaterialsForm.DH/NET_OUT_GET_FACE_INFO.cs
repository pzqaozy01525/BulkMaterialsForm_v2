// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_FACE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_FACE_INFO
{
	public uint dwSize;

	public int nFaceData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40960)]
	public byte[] szFaceData;

	public int nPhotoData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public int[] nInPhotoDataLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public int[] nOutPhotoDataLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public IntPtr[] pPhotoData;
}
