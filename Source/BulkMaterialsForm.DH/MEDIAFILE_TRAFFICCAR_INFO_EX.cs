// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.MEDIAFILE_TRAFFICCAR_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct MEDIAFILE_TRAFFICCAR_INFO_EX
{
	public uint dwSize;

	public MEDIAFILE_TRAFFICCAR_INFO stuInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szDeviceAddr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVehicleSign;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szCustomParkNo;

	public ushort wVehicleSubBrand;

	public ushort wVehicleYearModel;

	public NET_TIME stuEleTagInfoUTC;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_RECORD_SNAP_FLAG_TYPE[] emFalgLists;

	public int nFalgCount;

	public EM_SAFE_BELT_STATE emSafeBelSate;

	public EM_CALLING_STATE emCallingState;

	public int nAttachMentNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_ATTACH_MENET_INFO[] stuAttachMent;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCountry;

	public EM_CATEGORY_TYPE emCarType;

	public EM_NET_SUNSHADE_STATE emSunShadeState;

	public EM_SMOKING_STATE emSmokingState;

	public int nAnnualInspection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public int nPicIDHigh;

	public int nPicIDLow;

	public NET_UPLOAD_CLIENT_INFO stuClient1;

	public NET_UPLOAD_CLIENT_INFO stuClient2;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 96)]
	public string szExtraPlateNumber;

	public int nExtraPlateNumberNum;

	public uint nEntranceTime;

	public uint nOilTime;

	public uint nExitTime;

	public bool bRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;

	public NET_PLATE_IMAGE_INFO stuPlateImageInfo;

	public NET_CARBODY_IMAGE_INFO stuCarBodyImageInfo;
}
