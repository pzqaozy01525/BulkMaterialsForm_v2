// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_CUSTOM_WEIGHT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_CUSTOM_WEIGHT_INFO
{
	public uint dwRoughWeight;

	public uint dwTareWeight;

	public uint dwNetWeight;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 28)]
	public byte[] bReserved;
}
