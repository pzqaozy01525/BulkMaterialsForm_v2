// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SPLIT_SET_OSD_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SPLIT_SET_OSD_EX
{
	public uint dwSize;

	public int nChannel;

	public int nWindow;

	public int nOSDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public NET_SPLIT_OSD[] stuOSD;
}
