// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CAMERA_STATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CAMERA_STATE_INFO
{
	public int nChannel;

	public EM_CAMERA_STATE_TYPE emConnectionState;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] szReserved;
}
