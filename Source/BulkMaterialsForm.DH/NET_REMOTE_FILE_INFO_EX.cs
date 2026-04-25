// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_REMOTE_FILE_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_REMOTE_FILE_INFO_EX
{
	public uint dwSize;

	public bool bDirectory;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szPath;

	public NET_TIME stuCreateTime;

	public NET_TIME stuModifyTime;

	public long nFileSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szFileType;
}
