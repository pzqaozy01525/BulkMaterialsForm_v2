// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_FACE_DETECTION_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_FACE_DETECTION_PARAM
{
	public uint dwSize;

	public int nChannelID;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public EM_FACEPIC_TYPE emPicType;

	public bool bDetailEnable;

	public NET_MEDIAFILE_FACE_DETECTION_DETAIL_PARAM stuDetail;

	public EM_DEV_EVENT_FACEDETECT_SEX_TYPE emSex;

	public bool bAgeEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] nAgeRange;

	public int nEmotionValidNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emEmotion;

	public EM_FACEDETECT_GLASSES_TYPE emGlasses;

	public EM_MASK_STATE_TYPE emMask;

	public EM_BEARD_STATE_TYPE emBeard;

	public int nIsStranger;

	public bool bOnlySupportRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;
}
