// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_MULTIFACE_DETECT_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_MULTIFACE_DETECT_STATE
{
	public int nProgress;

	public NET_IMAGE_RELATION stuImageRelation;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
