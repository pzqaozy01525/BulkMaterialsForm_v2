// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RESERVED_COMMON

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RESERVED_COMMON
{
	public uint dwStructSize;

	public IntPtr pIntelBox;

	public uint dwSnapFlagMask;

	public IntPtr pstuOfflineParam;

	public IntPtr pstuPath;

	public EM_PATH_MODE emPathMode;

	public IntPtr pImageType;

	public int nImageTypeNum;

	public bool bFlagCustomInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szCustomInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szReserved;
}
