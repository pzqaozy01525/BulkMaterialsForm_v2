// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_NIGHTOPTIONS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_NIGHTOPTIONS
{
	public byte bEnable;

	public byte bSunriseHour;

	public byte bSunriseMinute;

	public byte bSunriseSecond;

	public byte bSunsetHour;

	public byte bSunsetMinute;

	public byte bSunsetSecond;

	public byte bWhiteBalance;

	public byte bGainRed;

	public byte bGainBlue;

	public byte bGainGreen;

	public byte bGain;

	public byte bGainAuto;

	public byte bBrightnessThreshold;

	public byte ReferenceLevel;

	public byte bExposureSpeed;

	public float ExposureValue1;

	public float ExposureValue2;

	public byte bAutoApertureEnable;

	public byte bWideDynamicRange;

	public ushort wNightSyncValue;

	public ushort wNightSyncValueMillValue;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public byte[] res;
}
