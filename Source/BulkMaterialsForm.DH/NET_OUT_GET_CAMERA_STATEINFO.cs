// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_CAMERA_STATEINFO

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_CAMERA_STATEINFO
{
	public uint dwSize;

	public int nValidNum;

	public int nMaxNum;

	public IntPtr pCameraStateInfo;
}
