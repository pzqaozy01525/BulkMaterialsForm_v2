// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_ALL_PARKING_SPACE_STATUS_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_ALL_PARKING_SPACE_STATUS_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] byReserved;

	public IntPtr pstuParkingSpaceInfo;

	public int nMaxParkingSpace;

	public int nParkingSpaceNum;

	public NET_EM_PARKING_SPACE_SCENE_TYPE emSceneType;

	public NET_EM_PARKING_SPACE_STATISTICS_MODE emStatisticsMode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_PARKING_SPACE_AREA_STATUS[] stuAreaStatus;

	public int nAreaStatusNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public char[] szReserved;
}
