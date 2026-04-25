// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_COMM_ATTACHMENT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_COMM_ATTACHMENT
{
	public EM_COMM_ATTACHMENT_TYPE emAttachmentType;

	public NET_RECT stuRect;

	public uint nConf;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] bReserved;
}
