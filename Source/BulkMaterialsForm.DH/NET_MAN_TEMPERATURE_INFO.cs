// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MAN_TEMPERATURE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MAN_TEMPERATURE_INFO
{
	public float fCurrentTemperature;

	public EM_HUMAN_TEMPERATURE_UNIT emTemperatureUnit;

	public bool bIsOverTemperature;

	public EM_HUMAN_TEMPERATURE_STATUS emTemperatureStatus;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
