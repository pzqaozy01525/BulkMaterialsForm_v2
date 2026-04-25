// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CAMERA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CAMERA_INFO
{
	public int nUniqueChannel;

	public uint nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szControlID;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	public EM_CAMERA_CHANNEL_TYPE emChannelType;

	public EM_VIDEO_STREAM emVideoStream;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
