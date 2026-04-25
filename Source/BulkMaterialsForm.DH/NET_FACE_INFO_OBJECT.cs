// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_INFO_OBJECT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_INFO_OBJECT
{
	public NET_IMAGE_INFO stuImageInfo;

	public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;

	public uint nAge;

	public EM_FACEDETECT_GLASSES_TYPE emGlasses;

	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE emEmotion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	public EM_EYE_STATE_TYPE emEye;

	public EM_MOUTH_STATE_TYPE emMouth;

	public EM_MASK_STATE_TYPE emMask;

	public EM_BEARD_STATE_TYPE emBeard;

	public int nAttractive;

	public NET_EULER_ANGLE stuFaceCaptureAngle;

	public uint nFaceQuality;

	public double dMaxTemp;

	public uint nIsOverTemp;

	public uint nIsUnderTemp;

	public EM_TEMPERATURE_UNIT emTempUnit;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2012)]
	public byte[] byReserved;
}
