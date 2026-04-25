// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_NONMOTOR_PLATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_NONMOTOR_PLATE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPlateNumber;

	public NET_RECT stuBoundingBox;

	public NET_RECT stuOriginalBoundingBox;

	public NET_NONMOTOR_PLATE_IMAGE stuPlateImage;

	public EM_PLATE_COLOR_TYPE emPlateColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
	public byte[] byReserved;
}
