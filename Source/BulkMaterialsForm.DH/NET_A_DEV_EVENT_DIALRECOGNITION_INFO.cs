// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_DIALRECOGNITION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_DIALRECOGNITION_INFO
{
	public uint nChannelID;

	public uint nPresetID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szTaskID;

	public EM_INSTRUMENT_TYPE emType;

	public int nRetImageInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_IMAGE_INFO_EX[] stuImgaeInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)]
	public string szDialResult;

	public int nOriginalImageOffset;

	public int nOriginalImageLength;

	public uint nAlarmType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDialSubType;

	public float fUpperThreshold;

	public float fLowerThreshold;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public NET_RECT[] stuBoundingBox;

	public int nRetBoundingBoxNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 968)]
	public string szReserved;
}
