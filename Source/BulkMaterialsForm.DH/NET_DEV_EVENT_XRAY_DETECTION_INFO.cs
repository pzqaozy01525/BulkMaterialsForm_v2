// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_XRAY_DETECTION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_XRAY_DETECTION_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] Reserved;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public EM_CLASS_TYPE emClassType;

	public NET_PACKAGE_INFO stuPacketInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] Reserved1;

	public uint nObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_INSIDE_OBJECT[] stuInsideObj;

	public uint nSlaveViewObjectNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_INSIDE_OBJECT[] stuSlaveViewInsideObj;

	public uint nImageInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_XRAY_IMAGE_INFO[] stuImageInfo;

	public uint nViewCustomInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_XRAY_CUSTOM_INFO[] stuViewCustomInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPackageTag;

	public EM_XRAY_PACKAGE_MODE emPackageMode;

	public int nRelatedImageNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_XRAY_RELATED_IMAGE_INFO[] stuRelatedImageInfo;

	public int nBarCodeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_BAR_CODE_INFO[] stuBarCodeInfo;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 372)]
	public byte[] byReserved;
}
