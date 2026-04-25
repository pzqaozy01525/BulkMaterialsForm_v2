// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_CALIBRATION_PARAS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_CALIBRATION_PARAS
{
	public int nCalibrationPosNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved1;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_RADAR_CALIBRATIONPOS[] stuCalibrationPos;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSDLinkIP;

	public double dLinkSDHeight;

	public double dTiltRecoupAngle;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
