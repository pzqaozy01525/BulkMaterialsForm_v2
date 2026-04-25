// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AV_CFG_TourLink

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_AV_CFG_TourLink
{
	public int nStructSize;

	public bool bEnable;

	public EM_CFG_SPLITMODE emSplitMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public int[] nChannels;

	public int nChannelCount;
}
