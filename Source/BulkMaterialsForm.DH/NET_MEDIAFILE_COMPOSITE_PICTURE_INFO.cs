// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_COMPOSITE_PICTURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_COMPOSITE_PICTURE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szPicturePath;

	public uint nPictureLength;

	public uint nGroupID;

	public uint nCountInGroup;

	public uint nIndexInGroup;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDefendCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
