// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCENE_IMAGE_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCENE_IMAGE_INFO_EX
{
	public uint nOffSet;

	public uint nLength;

	public uint nWidth;

	public uint nHeight;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;

	public uint nIndexInData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 42)]
	public string szImageID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
	public string szReserved;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 460)]
	public byte[] byReserved;
}
