// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_CAPTURE_FINGER_PRINT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_CAPTURE_FINGER_PRINT
{
	public uint dwSize;

	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szReaderID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
	public string szUserID;
}
