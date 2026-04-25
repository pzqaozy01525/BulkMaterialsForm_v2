// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PIG_TEMPERATURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PIG_TEMPERATURE_INFO
{
	public uint nPigNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public NET_PIG_TEMPERATURE_DATA[] stuPigInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserve;
}
