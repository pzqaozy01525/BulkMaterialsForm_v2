// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_PLATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_PLATE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szFrontPlateNumber;

	public EM_PLATE_COLOR_TYPE emFrontPlateColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szBackPlateNumber;

	public EM_PLATE_COLOR_TYPE emBackPlateColor;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] reversed;
}
