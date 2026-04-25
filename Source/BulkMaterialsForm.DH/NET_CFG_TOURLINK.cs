// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_TOURLINK

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_TOURLINK
{
	public bool bEnable;

	public EM_CFG_SPLITMODE emSplitMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nChannels;

	public int nChannelCount;
}
