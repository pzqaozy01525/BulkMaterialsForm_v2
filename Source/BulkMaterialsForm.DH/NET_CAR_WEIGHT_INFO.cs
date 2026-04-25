// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CAR_WEIGHT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CAR_WEIGHT_INFO
{
	public uint nAxleNum;

	public uint nMaxAxleDistance;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public uint[] nAxleWeightInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
	public uint[] nAxleDistanceInfo;

	public uint nOverWeight;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
