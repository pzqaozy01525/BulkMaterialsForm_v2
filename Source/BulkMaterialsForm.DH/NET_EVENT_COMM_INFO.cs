// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_COMM_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_COMM_INFO
{
	public EM_NTP_STATUS emNTPStatus;

	public int nDriversNum;

	public IntPtr pstDriversInfo;

	public IntPtr pszFilePath;

	public IntPtr pszFTPPath;

	public IntPtr pszVideoPath;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_EVENT_COMM_SEAT[] stCommSeat;

	public int nAttachmentNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_EVENT_COMM_ATTACHMENT[] stuAttachment;

	public int nAnnualInspectionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_RECT[] stuAnnualInspection;

	public float fHCRatio;

	public float fNORatio;

	public float fCOPercent;

	public float fCO2Percent;

	public float fLightObscuration;

	public int nPictureNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
	public NET_EVENT_PIC_INFO[] stuPicInfos;

	public float fTemperature;

	public int nHumidity;

	public float fPressure;

	public float fWindForce;

	public uint nWindDirection;

	public float fRoadGradient;

	public float fAcceleration;

	public NET_RFIDELETAG_INFO stuRFIDEleTagInfo;

	public NET_EVENT_PIC_INFO stuBinarizedPlateInfo;

	public NET_EVENT_PIC_INFO stuVehicleBodyInfo;

	public EM_VEHICLE_TYPE emVehicleTypeInTollStation;

	public EM_SNAPCATEGORY emSnapCategory;

	public int nRegionCode;

	public EM_VEHICLE_TYPE_BY_FUNC emVehicleTypeByFunc;

	public EM_STANDARD_VEHICLE_TYPE emStandardVehicleType;

	public uint nExtraPlateCount;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 96)]
	public string szExtraPlateNumber;

	public EM_OVERSEA_VEHICLE_CATEGORY_TYPE emOverseaVehicleCategory;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szProvince;

	public NET_EVENT_RADAR_INFO stuRadarInfo;

	public NET_EVENT_GPS_INFO stuGPSInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_EXTRA_PLATES[] stuExtraPlates;

	public int nExtraPlatesCount;

	public uint nPlateRecogniseConf;

	public uint nVecPostureConf;

	public uint nVecColorConf;

	public uint nSpecialVehConf;

	public uint nIsLargeAngle;

	public uint nIsRelatedPlate;

	public uint nDetectConf;

	public uint nClarity;

	public uint nCompleteScore;

	public uint nQeScore;

	public float fSpeedFloat;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] bReserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szCountry;
}
