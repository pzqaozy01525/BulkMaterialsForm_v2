// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OSD_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OSD_INFO
{
	public NET_BLACK_REGION_INFO stBackRegionInfo;

	public int nOSDAttrScheme;

	public NET_OSD_WHOLE_ATTR stOSDAttrScheme;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_OSD_CUSTOM_SORT[] stOSDCustomSorts;

	public int nOSDCustomSortNum;

	public int nRedLightTimeDisplay;

	public char cSeperater;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szOSDOrder;

	public int nOSDContentScheme;

	public NET_OSD_CUSTOM_INFO stOSDCustomInfo;
}
