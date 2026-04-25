// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_DATA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_DATA
{
	public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;

	public int nAge;

	public uint nFeatureValidNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emFeature;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	public EM_EYE_STATE_TYPE emEye;

	public EM_MOUTH_STATE_TYPE emMouth;

	public EM_MASK_STATE_TYPE emMask;

	public EM_BEARD_STATE_TYPE emBeard;

	public int nAttractive;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public NET_EULER_ANGLE stuFaceCaptureAngle;

	public uint nFaceQuality;

	public int nFaceAlignScore;

	public int nFaceClarity;

	public double dbTemperature;

	public bool bAnatomyTempDetect;

	public EM_HUMAN_TEMPERATURE_UNIT emTemperatureUnit;

	public bool bIsOverTemp;

	public bool bIsUnderTemp;

	public NET_FACE_ORIGINAL_SIZE stuOriginalSize;

	public EM_GLASS_STATE_TYPE emGlass;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] bReserved;
}
