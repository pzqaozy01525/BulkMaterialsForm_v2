// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PARKING_SPACE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PARKING_SPACE_INFO
{
	public int nLane;

	public EM_PARKING_SPACE_STATUS emParkStatus;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public char[] szCustomParkNo;

	public EM_PARKINGSPACE_TYPE emSpaceType;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] szReserved;
}
