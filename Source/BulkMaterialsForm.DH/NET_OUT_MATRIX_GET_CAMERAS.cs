// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_MATRIX_GET_CAMERAS

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_MATRIX_GET_CAMERAS
{
	public uint dwSize;

	public IntPtr pstuCameras;

	public int nMaxCameraCount;

	public int nRetCameraCount;
}
