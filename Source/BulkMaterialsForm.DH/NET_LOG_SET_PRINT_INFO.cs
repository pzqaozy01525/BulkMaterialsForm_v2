// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_LOG_SET_PRINT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_LOG_SET_PRINT_INFO
{
	public uint dwSize;

	public int bSetFilePath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szLogFilePath;

	public int bSetFileSize;

	public uint nFileSize;

	public int bSetFileNum;

	public uint nFileNum;

	public int bSetPrintStrategy;

	public uint nPrintStrategy;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public fSDKLogCallBack cbSDKLogCallBack;

	public IntPtr dwUser;
}
