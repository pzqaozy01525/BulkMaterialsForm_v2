// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_DECODER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_DECODER_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDecType;

	public int nMonitorNum;

	public int nEncoderNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] szSplitMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] bMonitorEnable;

	public byte bTVTipDisplay;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] reserved1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public byte[] byLayoutEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public uint[] dwLayoutEnMask;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] reserved;
}
