// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_EXPORT_FACE_DB

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_EXPORT_FACE_DB
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPassWord;

	public fExportStateCallBack cbExportFaceDbCallBack;

	public IntPtr dwUser;

	public int nWaitTime;

	public int nLogicChannel;
}
