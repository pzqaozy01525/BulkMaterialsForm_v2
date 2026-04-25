// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SNAP_PIC_TO_FILE_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SNAP_PIC_TO_FILE_PARAM
{
	public uint dwSize;

	public NET_SNAP_PARAMS stuParam;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;
}
