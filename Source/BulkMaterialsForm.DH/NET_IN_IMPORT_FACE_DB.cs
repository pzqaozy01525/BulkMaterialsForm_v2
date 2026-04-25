// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_IMPORT_FACE_DB

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_IMPORT_FACE_DB
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPassWord;

	public IntPtr pszFaceDBPath;

	public fImportFaceDbCallBack cbImportState;

	public IntPtr dwUser;

	public int nWaitTime;

	public uint nFaceDBFileNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8192)]
	public string szFaceDBFilePath;

	public int nLogicChannelNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public int[] nLogicChannels;
}
