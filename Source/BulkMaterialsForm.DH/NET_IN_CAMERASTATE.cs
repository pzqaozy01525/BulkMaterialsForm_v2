// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_CAMERASTATE

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_CAMERASTATE
{
	public uint dwSize;

	public IntPtr pChannels;

	public int nChannels;

	public fCameraStateCallBack cbCamera;

	public IntPtr dwUser;
}
