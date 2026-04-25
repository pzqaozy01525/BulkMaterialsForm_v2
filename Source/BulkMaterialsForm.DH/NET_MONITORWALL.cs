// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MONITORWALL

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MONITORWALL
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nGridLine;

	public int nGridColume;

	public IntPtr pstuBlocks;

	public int nMaxBlockCount;

	public int nRetBlockCount;

	public bool bDisable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDesc;
}
