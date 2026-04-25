// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_FACEDETECT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_FACEDETECT_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public NET_MSG_OBJECT stuObject;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] reserved;

	public byte byImageIndex;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] DetectRegion;

	public uint dwSnapFlagMask;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szSnapDevAddress;

	public uint nOccurrenceCount;

	public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;

	public int nAge;

	public uint nFeatureValidNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emFeature;

	public int nFacesNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_FACE_INFO[] stuFaces;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	public EM_EYE_STATE_TYPE emEye;

	public EM_MOUTH_STATE_TYPE emMouth;

	public EM_MASK_STATE_TYPE emMask;

	public EM_BEARD_STATE_TYPE emBeard;

	public int nAttractive;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved2;

	public NET_FEATURE_VECTOR stuFeatureVector;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szFeatureVersion;

	public EM_FACE_DETECT_STATUS emFaceDetectStatus;

	public NET_EULER_ANGLE stuFaceCaptureAngle;

	public uint nFaceQuality;

	public double dHumanSpeed;

	public int nFaceAlignScore;

	public int nFaceClarity;

	public bool bHumanTemperature;

	public NET_HUMAN_TEMPERATURE_INFO stuHumanTemperature;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCameraID;

	public NET_RESOLUTION_INFO stuResolution;

	public NET_FACE_ORIGINAL_SIZE stuOriginalSize;

	public EM_GLASS_STATE_TYPE emGlass;

	public EM_HAT_STYLE emHat;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 396)]
	public byte[] bReserved;
}
