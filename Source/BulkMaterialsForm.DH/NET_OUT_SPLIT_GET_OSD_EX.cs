// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_SPLIT_GET_OSD_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_SPLIT_GET_OSD_EX
{
	public uint dwSize;

	public int nOSDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_SPLIT_OSD[] stuOSD;
}
