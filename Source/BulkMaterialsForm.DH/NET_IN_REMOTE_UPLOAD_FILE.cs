// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_REMOTE_UPLOAD_FILE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_REMOTE_UPLOAD_FILE
{
	public uint dwSize;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szFileSrc;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFileNameDst;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szFolderDst;

	public fRemoteUploadFileCallBack cbUploadFile;

	public IntPtr dwUser;

	public uint nPacketLen;
}
