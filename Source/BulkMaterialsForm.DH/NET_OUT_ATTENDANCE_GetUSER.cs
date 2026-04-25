// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ATTENDANCE_GetUSER

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ATTENDANCE_GetUSER
{
	public uint dwSize;

	public NET_ATTENDANCE_USERINFO stuUserInfo;

	public int nMaxLength;

	public IntPtr pbyPhotoData;
}
