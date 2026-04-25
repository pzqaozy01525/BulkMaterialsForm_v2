// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_REMOTE_STREAM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_REMOTE_STREAM_INFO
{
	public EM_STREAM_PROTOCOL_TYPE emStreamProtocolType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szIp;

	public ushort wPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szUser;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPwd;

	public int nChannelID;

	public uint nStreamType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string byReserved;
}
