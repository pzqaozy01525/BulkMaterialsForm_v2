// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BAR_CODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BAR_CODE_INFO
{
	public int nCodeCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4096)]
	public string szCode;

	public NET_BAR_CODE_IMAGE stuImage;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
