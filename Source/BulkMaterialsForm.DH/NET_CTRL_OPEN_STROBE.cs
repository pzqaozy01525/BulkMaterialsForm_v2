// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_OPEN_STROBE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_OPEN_STROBE
{
	public uint dwSize;

	public int nChannelId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPlateNumber;

	public EM_OPEN_STROBE_TYPE emOpenType;
}
