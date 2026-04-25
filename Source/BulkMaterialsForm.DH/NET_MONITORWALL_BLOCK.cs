// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MONITORWALL_BLOCK

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MONITORWALL_BLOCK
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCompositeID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szControlID;

	public int nSingleOutputWidth;

	public int nSingleOutputHeight;

	public NET_RECT stuRect;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_TSECT_ARRAY[] stuTimeSection;

	public IntPtr pstuOutputs;

	public int nMaxOutputCount;

	public int nRetOutputCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szBlockType;

	public int nOutputDelay;
}
