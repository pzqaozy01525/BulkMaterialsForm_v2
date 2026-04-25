// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_FACE_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_FACE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public int nFaceData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_ACCESS_FACE_INFO_FaceData[] szFaceData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public int[] nFaceDataLen;

	public int nFacePhoto;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public int[] nInFacePhotoLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public int[] nOutFacePhotoLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public IntPtr[] pFacePhoto;

	public bool bFaceDataExEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public IntPtr[] pFaceDataEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1960)]
	public byte[] byReserved;
}
