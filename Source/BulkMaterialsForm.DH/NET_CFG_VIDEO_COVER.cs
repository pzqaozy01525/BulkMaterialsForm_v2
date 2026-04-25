// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_VIDEO_COVER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_VIDEO_COVER
{
	public int nTotalBlocks;

	public int nCurBlocks;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_CFG_COVER_INFO[] stuCoverBlock;
}
