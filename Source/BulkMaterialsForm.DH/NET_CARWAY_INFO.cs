// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CARWAY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CARWAY_INFO
{
	public byte bCarWayID;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserve;

	public byte bSigCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public NET_SIG_CARWAY_INFO[] stuSigInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	public byte[] bReserved;
}
