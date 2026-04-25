// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_JUNCTION_CUSTOM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_JUNCTION_CUSTOM_INFO
{
	public NET_EVENT_CUSTOM_WEIGHT_INFO stuWeightInfo;

	public uint nCbirFeatureOffset;

	public uint nCbirFeatureLength;

	public uint dwVehicleHeadDirection;

	public uint nAvailableSpaceNum;

	public NET_RADAR_FREE_STREAM stuRadarFreeStream;

	public NET_CUSTOM_MEASURE_TEMPER stuMeasureTemper;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	public byte[] bReserved;
}
