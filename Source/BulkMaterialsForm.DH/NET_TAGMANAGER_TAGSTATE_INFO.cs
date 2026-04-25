// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TAGMANAGER_TAGSTATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TAGMANAGER_TAGSTATE_INFO
{
	public int nChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szContext;

	public NET_TIME stuStartTime;

	public int nSubTagVaildNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_TAGMANAGER_SUB_TAG_INFO[] stuSubTag;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szContextEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 768)]
	public byte[] byReserved;
}
