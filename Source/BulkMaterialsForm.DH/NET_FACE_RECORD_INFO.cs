// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_RECORD_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_RECORD_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserName;

	public int nRoom;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_ROOM[] szRoomNo;

	public int nFaceData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 40960)]
	public byte[] szFaceData;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public int[] nFaceDataLen;

	public int nFacePhoto;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public int[] nFacePhotoLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public IntPtr[] pszFacePhoto;

	public bool bValidDate;

	public NET_TIME stuValidDateStart;

	public NET_TIME stuValidDateEnd;

	public int nValidCounts;

	public bool bValidCountsEnable;

	public bool bFaceDataExEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public IntPtr[] pszFaceDataEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 240)]
	public byte[] byReserved;
}
