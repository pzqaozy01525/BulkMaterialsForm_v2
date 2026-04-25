// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_TRAFFIC_PARKING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_TRAFFIC_PARKING_INFO
{
	public int nFeaturePicAreaPointNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_POINT[] stFeaturePicArea;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 572)]
	public byte[] bReserved;
}
