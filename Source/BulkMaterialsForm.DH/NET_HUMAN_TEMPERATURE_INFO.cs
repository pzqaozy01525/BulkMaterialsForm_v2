// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_HUMAN_TEMPERATURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_HUMAN_TEMPERATURE_INFO
{
	public double dbTemperature;

	public EM_HUMAN_TEMPERATURE_UNIT emTemperatureUnit;

	public bool bIsOverTemp;

	public bool bIsUnderTemp;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
	public byte[] bReserved;
}
