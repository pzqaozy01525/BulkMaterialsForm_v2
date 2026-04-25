// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_WRIST_MEASURE_MODE_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_WRIST_MEASURE_MODE_PARAM
{
	public double dbTempThreshold;

	public double dbCorrectTemp;

	public double dbValidTempLowerLimit;

	public int nMeasureTimeout;

	public int nValidMeasureDistance;

	public int nInvalidMeasureDistance;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1020)]
	public byte[] byReserved;
}
