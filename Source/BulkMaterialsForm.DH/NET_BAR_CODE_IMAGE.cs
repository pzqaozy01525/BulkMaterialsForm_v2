// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BAR_CODE_IMAGE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BAR_CODE_IMAGE
{
	public uint nOffset;

	public uint nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 248)]
	public string szResvered;
}
