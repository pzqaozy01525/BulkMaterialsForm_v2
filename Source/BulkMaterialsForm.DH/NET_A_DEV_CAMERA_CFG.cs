// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_CAMERA_CFG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_CAMERA_CFG
{
	public uint dwSize;

	public byte bExposure;

	public byte bBacklight;

	public byte bAutoColor2BW;

	public byte bMirror;

	public byte bFlip;

	public byte bLensEn;

	public byte bLensFunction;

	public byte bWhiteBalance;

	public byte bSignalFormat;

	public byte bRotate90;

	public byte bReferenceLevel;

	public byte byReserve;

	public float ExposureValue1;

	public float ExposureValue2;

	public NET_A_DEV_NIGHTOPTIONS stuNightOptions;

	public byte bGainRed;

	public byte bGainBlue;

	public byte bGainGreen;

	public byte bFlashMode;

	public byte bFlashValue;

	public byte bFlashPole;

	public byte bExternalSyncPhase;

	public byte bFlashInitValue;

	public ushort wExternalSyncValue;

	public ushort wExternalSyncValueMillValue;

	public byte bWideDynamicRange;

	public byte byExposureCompensation;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 54)]
	public string bRev;
}
