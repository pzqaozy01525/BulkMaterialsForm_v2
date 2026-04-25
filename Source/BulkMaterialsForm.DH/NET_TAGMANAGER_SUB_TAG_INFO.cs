// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TAGMANAGER_SUB_TAG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TAGMANAGER_SUB_TAG_INFO
{
	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSubTagName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
