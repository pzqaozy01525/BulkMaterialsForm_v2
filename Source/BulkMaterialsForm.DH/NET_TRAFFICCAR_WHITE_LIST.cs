// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_TRAFFICCAR_WHITE_LIST

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_TRAFFICCAR_WHITE_LIST
{
	public bool bTrustCar;

	public NET_TIME stuBeginTime;

	public NET_TIME stuCancelTime;

	public NET_WHITE_LIST_AUTHORITY_LIST stuAuthorityList;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] bReserved;
}
