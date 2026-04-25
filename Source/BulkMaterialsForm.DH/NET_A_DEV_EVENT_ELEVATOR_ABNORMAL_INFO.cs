// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_ELEVATOR_ABNORMAL_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_ELEVATOR_ABNORMAL_INFO
{
	public int nChannelID;

	public int nEventID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public double dbPTS;

	public NET_TIME_EX UTC;

	public int nAction;

	public EM_CLASS_TYPE emClassType;

	public int nDetectRegionPointNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
	public NET_POINT[] stuDetectRegion;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public NET_POINT[] stuDirection;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 908)]
	public byte[] byReserved1;
}
