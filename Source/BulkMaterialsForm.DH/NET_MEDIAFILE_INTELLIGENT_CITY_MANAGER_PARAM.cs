// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_INTELLIGENT_CITY_MANAGER_PARAM

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_INTELLIGENT_CITY_MANAGER_PARAM
{
	public uint dwSize;

	public int nFileType;

	public int nChannelID;

	public NET_TIME stuBeginTime;

	public NET_TIME stuEndTime;

	public NET_INTELLIGENT_CITY_MANAGER_FILTER stuFilter;

	public bool bOnlySupportRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;
}
