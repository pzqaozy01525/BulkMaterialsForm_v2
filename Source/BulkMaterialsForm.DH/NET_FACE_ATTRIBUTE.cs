// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_ATTRIBUTE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_ATTRIBUTE
{
	public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;

	public int nAge;

	public uint nFeatureValidNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emFeatures;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	public EM_EYE_STATE_TYPE emEye;

	public EM_MOUTH_STATE_TYPE emMouth;

	public EM_MASK_STATE_TYPE emMask;

	public EM_BEARD_STATE_TYPE emBeard;

	public int nAttractive;

	public NET_RECT stuBoundingBox;

	public NET_EULER_ANGLE stuFaceCaptureAngle;

	public uint nFaceQuality;

	public int nFaceAlignScore;

	public int nFaceClarity;

	public NET_POINT stuFaceCenter;

	public EM_FACEDETECT_GLASSES_TYPE emGlass;

	public uint nFaceDetectConf;

	public NET_FACE_ORIGINAL_SIZE stuOriginalSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public int[] arrAngleStatus;

	public uint nIlluminationScore;

	public sbyte nLeftEyeCoverConf;

	public sbyte nLeftCheekCoverConf;

	public sbyte nMouthCoverConf;

	public sbyte nRightEyeCoverConf;

	public sbyte nRightCheekCoverConf;

	public sbyte nChinCoverConf;

	public sbyte nIsCompleteFace;

	public sbyte nSaturationScore;

	public sbyte nBrowCoverConf;

	public sbyte nNoseCoverConf;

	public EM_AGE_SEG emAgeSeg;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
	public byte[] bReserved;
}
