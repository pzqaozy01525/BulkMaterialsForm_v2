// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DETECT_PLATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DETECT_PLATE_INFO
{
	public uint nObjectID;

	public uint nRelativeID;

	public NET_EVENT_PIC_INFO stuPlateImage;

	public EM_NET_PLATE_TYPE emPlateType;

	public EM_NET_PLATE_COLOR_TYPE emPlateColor;

	public uint nConfidence;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 3)]
	public string szCountry;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	public byte[] bReserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPlateNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] bReserved;
}
