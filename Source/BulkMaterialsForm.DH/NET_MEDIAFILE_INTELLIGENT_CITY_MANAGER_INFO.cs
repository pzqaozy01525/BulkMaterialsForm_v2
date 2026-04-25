// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MEDIAFILE_INTELLIGENT_CITY_MANAGER_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MEDIAFILE_INTELLIGENT_CITY_MANAGER_INFO
{
	public uint dwSize;

	public int nChannelID;

	public NET_TIME stuBeginTime;

	public NET_TIME stuEndTime;

	public int nEvent;

	public int nFileType;

	public NET_TIME stuEventTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szEventCode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szEventAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szSourceID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_MEDIAFILE_COMPOSITE_PICTURE_INFO[] stuCompositePicInfo;

	public uint nCompositePicCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_MEDIAFILE_ORIGINAL_PICTURE_INFO[] stuOriginPicInfo;

	public uint nOriginPicCount;

	public NET_INTELLIGENT_CITY_TRAFFIC_CAR_INFO stuTrafficCar;

	public bool bTrafficCar;

	public uint nPresetID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szShopAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPresetName;

	public uint nViolationDuration;

	public bool bRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;
}
