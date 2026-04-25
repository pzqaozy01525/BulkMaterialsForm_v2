// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_FACEINFO_DO_FIND

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_FACEINFO_DO_FIND
{
	public uint dwSize;

	public int nRetNum;

	public IntPtr pstuInfo;

	public int nMaxNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;
}
