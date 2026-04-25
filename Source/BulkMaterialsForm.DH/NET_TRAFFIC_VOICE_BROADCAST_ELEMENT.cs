// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_VOICE_BROADCAST_ELEMENT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_VOICE_BROADCAST_ELEMENT
{
	public EM_VOICE_BROADCAST_ELEMENT_TYPE emType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szPrefix;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szPostfix;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
