// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_DOWNLOAD_REMOTE_FILE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_DOWNLOAD_REMOTE_FILE
{
	public uint dwSize;

	public uint dwMaxFileBufLen;

	public IntPtr pstFileBuf;

	public uint dwRetFileBufLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;
}
