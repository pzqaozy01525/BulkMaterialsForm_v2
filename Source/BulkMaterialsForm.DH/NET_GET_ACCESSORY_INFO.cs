// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_GET_ACCESSORY_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_GET_ACCESSORY_INFO
{
	public uint dwSize;

	public uint nSNNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1792)]
	public string szSN;

	public uint nMaxInfoNum;

	public IntPtr pstuInfo;

	public uint nInfoNum;
}
