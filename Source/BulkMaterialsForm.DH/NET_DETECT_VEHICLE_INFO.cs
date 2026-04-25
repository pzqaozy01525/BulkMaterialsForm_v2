// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DETECT_VEHICLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DETECT_VEHICLE_INFO
{
	public EM_VEHICLE_ACTION emAction;

	public uint nObjectID;

	public NET_EVENT_PIC_INFO stuVehicleImage;

	public NET_COLOR_RGBA stuColor;

	public EM_CATEGORY_TYPE emCategoryType;

	public uint nFrameSequence;

	public uint nCarLogoIndex;

	public uint nSubBrand;

	public uint nBrandYear;

	public uint nConfidence;

	public NET_RECT stuBoundingBox;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szText;

	public uint nSpeed;

	public uint nDirection;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] bReserved;
}
