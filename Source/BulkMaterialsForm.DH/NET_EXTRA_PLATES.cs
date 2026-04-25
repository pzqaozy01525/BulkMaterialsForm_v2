// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EXTRA_PLATES

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EXTRA_PLATES
{
	public uint nOffset;

	public uint nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szText;

	public EM_NET_PLATE_TYPE emCategory;

	public EM_NET_PLATE_COLOR_TYPE emColor;

	public NET_RECT stuArea;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string bReserved;
}
