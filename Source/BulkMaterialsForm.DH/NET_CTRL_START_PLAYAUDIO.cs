// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_START_PLAYAUDIO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_START_PLAYAUDIO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szAudioPath;
}
