// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MATRIX_CAMERA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MATRIX_CAMERA_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDevID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szControlID;

	public int nChannelID;

	public int nUniqueChannel;

	public bool bRemoteDevice;

	public NET_REMOTE_DEVICE stuRemoteDevice;

	public EM_STREAM_TYPE emStreamType;

	public EM_LOGIC_CHN_TYPE emChannelType;

	public bool bEnable;

	public EM_VIDEO_STREAM emVideoStream;
}
