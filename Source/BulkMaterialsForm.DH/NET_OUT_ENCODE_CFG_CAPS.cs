// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ENCODE_CFG_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ENCODE_CFG_CAPS
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public NET_STREAM_CFG_CAPS[] stuMainFormatCaps;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public NET_STREAM_CFG_CAPS[] stuExtraFormatCaps;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_STREAM_CFG_CAPS[] stuSnapFormatCaps;

	public int nMainFormCaps;

	public int nExtraFormCaps;

	public int nSnapFormatCaps;
}
