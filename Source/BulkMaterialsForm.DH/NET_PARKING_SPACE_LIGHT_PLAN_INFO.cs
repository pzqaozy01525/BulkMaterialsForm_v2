// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PARKING_SPACE_LIGHT_PLAN_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PARKING_SPACE_LIGHT_PLAN_INFO
{
	public EM_PARKINGSPACE_LIGHT_COLOR emColor;

	public EM_PARKINGSPACE_LIGHT_STATE emState;

	public int nKeepTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
