// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FACE_FILTER_CONDTION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FACE_FILTER_CONDTION
{
	public uint dwSize;

	public NET_TIME stStartTime;

	public NET_TIME stEndTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szMachineAddress;

	public int nRangeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] szRange;

	public EM_FACERECOGNITION_FACE_TYPE emFaceType;

	public int nGroupIdNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_FACE_FILTER_CONDTION_GROUPID[] szGroupId;

	public NET_TIME stBirthdayRangeStart;

	public NET_TIME stBirthdayRangeEnd;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byAge;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] byReserved;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public EM_DEV_EVENT_FACEDETECT_FEATURE_TYPE[] emEmotion;

	public int nEmotionNum;

	public int nUIDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
	public byte[] szUIDs;

	public int nUUIDNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2048)]
	public byte[] szUUIDs;
}
