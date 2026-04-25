// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_FACERECOGNITION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_FACERECOGNITION_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public int nEventID;

	public NET_TIME_EX UTC;

	public NET_MSG_OBJECT stuObject;

	public int nCandidateNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CANDIDATE_INFO[] stuCandidates;

	public byte bEventAction;

	public byte byImageIndex;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved1;

	public bool bGlobalScenePic;

	public NET_PIC_INFO stuGlobalScenePicInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szSnapDevAddress;

	public uint nOccurrenceCount;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public NET_FACE_DATA stuFaceData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUID;

	public NET_FEATURE_VECTOR stuFeatureVector;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szFeatureVersion;

	public EM_FACE_DETECT_STATUS emFaceDetectStatus;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSourceID;

	public NET_PASSERBY_INFO stuPasserbyInfo;

	public uint nStayTime;

	public NET_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 432)]
	public byte[] bReserved;

	public int nRetCandidatesExNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 50)]
	public NET_CANDIDATE_INFOEX[] stuCandidatesEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 22)]
	public string szSerialUUID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	public NET_CUSTOM_PROJECTS_INFO stuCustomProjects;

	public bool bIsDuplicateRemove;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved2;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_IMAGE_INFO_EX2[] stuImageInfo;

	public int nImageInfoNum;

	public NET_A_MSG_OBJECT_SUPPLEMENT stuObjectSupplement;

	public uint nMode;

	public NET_SCENE_IMAGE_INFO stuThumImageInfo;

	public NET_SCENE_IMAGE_INFO stuHumanImageInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szVideoPath;

	public bool bIsHighFrequencyAlarm;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szFrequencyAlarmName;

	public double PTS;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 272)]
	public string byReserved3;
}
