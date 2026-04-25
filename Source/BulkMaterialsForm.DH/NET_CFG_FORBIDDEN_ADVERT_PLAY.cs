// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_FORBIDDEN_ADVERT_PLAY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_FORBIDDEN_ADVERT_PLAY
{
	public uint dwSize;

	public uint nAdvertNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_CFG_FORBIDDEN_ADVERT_PLAY_INFO[] stuAdvertInfo;
}
