// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PIG_TEMPERATURE_DATA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PIG_TEMPERATURE_DATA
{
	public NET_RECT stuRect;

	public uint nID;

	public float fMaxTemperature;

	public float fMinTemperature;

	public float fAverageTemperature;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserve;
}
