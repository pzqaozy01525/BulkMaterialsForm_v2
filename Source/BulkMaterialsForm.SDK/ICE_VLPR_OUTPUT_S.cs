// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.SDK
// Type: BulkMaterialsForm.SDK.ICE_VLPR_OUTPUT_S

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.SDK;

public struct ICE_VLPR_OUTPUT_S
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string as8PlateNum;

	public ICE_RECT_S stPlateRect;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.Struct)]
	public ICE_RECT_S[] astPlateCharRect;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.R4)]
	public float[] aflPlateCharConfid;

	public float flConfidence;

	public int s32PlateIntensity;

	public int ePlateColor;

	public int ePlateType;

	public int eVehicleColor;

	public float flPlateAngleH;

	public float flPlateAngleV;

	public byte u8PlateColorRate;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 19)]
	public string astReserve;

	public uint u32FrameId;
}
