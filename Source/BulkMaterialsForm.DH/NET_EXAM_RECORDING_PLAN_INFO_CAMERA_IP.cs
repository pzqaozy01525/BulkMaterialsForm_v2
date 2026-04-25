// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EXAM_RECORDING_PLAN_INFO_CAMERA_IP

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EXAM_RECORDING_PLAN_INFO_CAMERA_IP
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCameraIP;
}
