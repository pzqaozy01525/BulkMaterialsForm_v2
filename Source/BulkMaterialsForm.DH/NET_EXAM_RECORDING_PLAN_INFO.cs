// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EXAM_RECORDING_PLAN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EXAM_RECORDING_PLAN_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNumber;

	public int nCameraIPNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_EXAM_RECORDING_PLAN_INFO_CAMERA_IP[] szCameraIP;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szResvered;
}
