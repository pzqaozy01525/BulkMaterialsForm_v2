// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACEINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACEINFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;

	public int nMD5;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
	public NET_MD5[] szMD5;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
