// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_FACERECOGNITION_PARAM

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_FACERECOGNITION_PARAM
{
	public uint dwSize;

	public NET_TIME stStartTime;

	public NET_TIME stEndTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 260)]
	public byte[] szMachineAddress;

	public int nAlarmType;

	public int abPersonInfo;

	public NET_FACERECOGNITION_PERSON_INFO stPersonInfo;

	public int nChannelId;

	public int nGroupIdNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8192)]
	public byte[] szGroupId;

	public bool abPersonInfoEx;

	public NET_FACERECOGNITION_PERSON_INFOEX stPersonInfoEx;

	public bool bSimilaryRangeEnable;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public int[] nSimilaryRange;

	public int nFileType;

	public bool bOnlySupportRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;
}
