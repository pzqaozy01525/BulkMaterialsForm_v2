// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_FACE_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_FACE_DETECTION_INFO
{
	public uint dwSize;

	public uint ch;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFilePath;

	public uint size;

	public NET_TIME starttime;

	public NET_TIME endtime;

	public uint nWorkDirSN;

	public byte nFileType;

	public byte bHint;

	public byte bDriveNo;

	public byte byPictureType;

	public uint nCluster;

	public EM_FACEPIC_TYPE emPicType;

	public uint dwObjectId;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public uint[] dwFrameSequence;

	public int nFrameSequenceNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_TIME_EX[] stTimes;

	public int nTimeStampNum;

	public int nPicIndex;

	public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;

	public int nAge;

	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE emEmotion;

	public EM_FACEDETECT_GLASSES_TYPE emGlasses;

	public long sizeEx;

	public EM_MASK_STATE_TYPE emMask;

	public EM_BEARD_STATE_TYPE emBeard;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	public EM_EYE_STATE_TYPE emEye;

	public EM_MOUTH_STATE_TYPE emMouth;

	public int nAttractive;

	public int nIsStranger;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFaceObjectUrl;

	public NET_EULER_ANGLE stuFaceCaptureAngle;

	public uint nFaceQuality;

	public NET_FACEDETECT_IMAGE_INFO stuSceneImage;

	public NET_POINT stuFaceCenter;

	public bool bOnlySupportRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;
}
