// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DELIVERY_FILE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DELIVERY_FILE_INFO
{
	public EM_DELIVERY_FILE_TYPE emFileType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFileURL;

	public int nImageSustain;

	public EM_PLAY_WITH_MODE emPlayWithMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
