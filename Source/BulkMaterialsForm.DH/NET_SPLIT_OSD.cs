// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SPLIT_OSD

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SPLIT_OSD
{
	public uint dwSize;

	public bool bEnable;

	public NET_COLOR_RGBA stuFrontColor;

	public NET_COLOR_RGBA stuBackColor;

	public NET_RECT stuFrontRect;

	public NET_RECT stuBackRect;

	public bool bRoll;

	public byte byRollMode;

	public byte byRoolSpeed;

	public byte byFontSize;

	public byte byTextAlign;

	public byte byType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] Reserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szContent;

	public float fPitch;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szFontType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szPattern;
}
