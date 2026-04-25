// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ATTACH_MENET_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ATTACH_MENET_INFO
{
	public EM_ATTACHMENT_TYPE emAttachMentType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] bReserved1;
}
