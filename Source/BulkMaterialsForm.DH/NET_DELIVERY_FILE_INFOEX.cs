// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DELIVERY_FILE_INFOEX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DELIVERY_FILE_INFOEX
{
	public EM_DELIVERY_FILE_TYPE emFileType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFileURL;

	public int nImageSustain;

	public EM_PLAY_WITH_MODE emPlayWithMode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szFileURLEx;

	public NET_CFG_TIME_SCHEDULE stuTimeSection;

	public int nSize;

	public int nID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
