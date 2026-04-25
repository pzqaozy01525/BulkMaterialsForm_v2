// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ADD_BYGROUP_RESULT

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ADD_BYGROUP_RESULT
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	public int nResultCam;

	public IntPtr pstResultCamera;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
