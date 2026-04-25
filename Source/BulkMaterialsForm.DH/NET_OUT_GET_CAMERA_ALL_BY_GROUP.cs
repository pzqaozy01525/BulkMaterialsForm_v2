// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_CAMERA_ALL_BY_GROUP

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_CAMERA_ALL_BY_GROUP
{
	public uint dwSize;

	public int nMaxCameraGroup;

	public int nCameraGroup;

	public IntPtr pstCameraGroupInfo;
}
