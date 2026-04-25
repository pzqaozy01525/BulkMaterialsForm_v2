// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_CAMERA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_CAMERA_INFO
{
	public byte bBrightnessEn;

	public byte bContrastEn;

	public byte bColorEn;

	public byte bGainEn;

	public byte bSaturationEn;

	public byte bBacklightEn;

	public byte bExposureEn;

	public byte bColorConvEn;

	public byte bAttrEn;

	public byte bMirrorEn;

	public byte bFlipEn;

	public byte iWhiteBalance;

	public byte iSignalFormatMask;

	public byte bRotate90;

	public byte bLimitedAutoExposure;

	public byte bCustomManualExposure;

	public byte bFlashAdjustEn;

	public byte bNightOptions;

	public byte iReferenceLevel;

	public byte bExternalSyncInput;

	public ushort usMaxExposureTime;

	public ushort usMinExposureTime;

	public byte bWideDynamicRange;

	public byte bDoubleShutter;

	public byte byExposureCompensation;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 109)]
	public byte[] bRev;
}
