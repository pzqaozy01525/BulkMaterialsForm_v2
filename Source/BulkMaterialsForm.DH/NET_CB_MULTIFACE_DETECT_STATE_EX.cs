// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_MULTIFACE_DETECT_STATE_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_MULTIFACE_DETECT_STATE_EX
{
	public int nProgress;

	public NET_IMAGE_RELATION_EX stuImageRelation;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
