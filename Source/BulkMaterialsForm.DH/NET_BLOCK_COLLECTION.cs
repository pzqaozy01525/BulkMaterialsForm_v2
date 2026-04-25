// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BLOCK_COLLECTION

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BLOCK_COLLECTION
{
	public uint dwSize;

	public EM_SPLIT_MODE emSplitMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_WINDOW_COLLECTION[] stuWnds;

	public int nWndsCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szName;

	public int nScreen;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCompositeID;

	public IntPtr pstuWndsEx;

	public int nMaxWndsCountEx;

	public int nRetWndsCountEx;

	public int nSplitOsdCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_SPLIT_OSD[] stuSplitOsd;

	public NET_SCREEEN_BACKGROUD stuScreenBackground;
}
