// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HISTORY_HUMAN_IMAGE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HISTORY_HUMAN_IMAGE_INFO
{
	public int nLength;

	public int nWidth;

	public int nHeight;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	public byte[] szFilePath;
}
