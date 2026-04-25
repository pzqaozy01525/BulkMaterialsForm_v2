// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_RADAR_CALIBRATION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_RADAR_CALIBRATION_INFO
{
	public uint dwSize;

	public int nCalibrationParasNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public NET_RADAR_CALIBRATION_PARAS[] stuCalibrationParas;

	public double dInstallHeight;

	public double dSlopeAngle;
}
