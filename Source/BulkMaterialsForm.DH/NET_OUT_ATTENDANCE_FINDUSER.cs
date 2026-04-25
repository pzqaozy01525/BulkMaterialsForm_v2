// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ATTENDANCE_FINDUSER

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ATTENDANCE_FINDUSER
{
	public uint dwSize;

	public int nTotalUser;

	public int nMaxUserCount;

	public IntPtr stuUserInfo;

	public int nRetUserCount;

	public int nMaxPhotoDataLength;

	public int nRetPhoteLength;

	public IntPtr pbyPhotoData;
}
