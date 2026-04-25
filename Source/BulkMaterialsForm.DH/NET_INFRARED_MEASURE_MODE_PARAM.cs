// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_INFRARED_MEASURE_MODE_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_INFRARED_MEASURE_MODE_PARAM
{
	public int nMaxDistance;

	public int nRetentionTime;

	public double dbTempThreshold;

	public double dbCorrectTemp;

	public double dbValidTempLowerLimit;

	public bool bDebugModelEnable;

	public bool bRectEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSensorType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
