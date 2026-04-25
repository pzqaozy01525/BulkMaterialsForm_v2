// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DETECT_BIG_PIC_INFO_EX

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DETECT_BIG_PIC_INFO_EX
{
	public int nPicID;

	public uint dwOffSet;

	public uint dwFileLenth;

	public uint dwWidth;

	public uint dwHeight;

	public int nDetectRegionNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szRequestID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szPath;

	public EM_COORDINATE_TYPE emCoordinateType;

	public EM_DETECT_OBJECT_TYPE emObjectType;

	public uint nTargetType;

	public int nProcessTypeNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public EM_DETECT_PROCESS_TYPE[] emProcessType;

	public IntPtr szData;

	public int nDataLen;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1016)]
	public byte[] bReserved;
}
