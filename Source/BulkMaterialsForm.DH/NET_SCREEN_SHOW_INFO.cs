// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCREEN_SHOW_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCREEN_SHOW_INFO
{
	public uint nScreenNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szText;

	public EM_SCREEN_TEXT_TYPE emTextType;

	public EM_SCREEN_TEXT_COLOR emTextColor;

	public EM_SCREEN_TEXT_ROLL_MODE emTextRollMode;

	public uint nRollSpeed;

	public int nDisplayEffect;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] byReserved;
}
