// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFIC_CALIBRATION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFIC_CALIBRATION_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szUnit;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] szCertificate;

	private NET_PERIOD_OF_VALIDITY stPeriodOfValidity;
}
