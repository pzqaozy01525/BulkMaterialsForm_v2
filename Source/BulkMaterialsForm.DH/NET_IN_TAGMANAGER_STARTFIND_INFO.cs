// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_TAGMANAGER_STARTFIND_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_TAGMANAGER_STARTFIND_INFO
{
	public uint dwSize;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szContext;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;
}
