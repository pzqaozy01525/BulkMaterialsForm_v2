// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_EXAM_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_EXAM_PARAM
{
	public uint dwSize;

	public int nChannelID;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCameraIP;
}
