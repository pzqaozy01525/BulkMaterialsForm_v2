// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_REMOTE_SPEAK_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_REMOTE_SPEAK_CAPS
{
	public uint dwSize;

	public int nChannelNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] nChannels;
}
