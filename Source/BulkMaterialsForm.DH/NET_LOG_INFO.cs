// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_LOG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_LOG_INFO
{
	public uint dwSize;

	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szLogType;

	public NET_LOG_MESSAGE stuLogMsg;
}
