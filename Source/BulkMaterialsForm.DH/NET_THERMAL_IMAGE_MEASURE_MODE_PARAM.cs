// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_THERMAL_IMAGE_MEASURE_MODE_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_THERMAL_IMAGE_MEASURE_MODE_PARAM
{
	public int nFaceCompareThreshold;

	public int nRetentionTime;

	public int nOverTempMaxDistance;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
