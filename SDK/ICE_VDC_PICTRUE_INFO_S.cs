using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.SDK;

public struct ICE_VDC_PICTRUE_INFO_S
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string cFileName;

	public IntPtr pstVbrResult;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 232)]
	public string data;

	public ICE_VLPR_OUTPUT_S stPlateInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
	public string data2;
}
