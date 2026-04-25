// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_DETAIL_DRIVEASSISTANT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_DETAIL_DRIVEASSISTANT_INFO
{
	public bool bValid;

	public int nVehicleWidth;

	public int nCamHeight;

	public int nCamToCarHead;

	public NET_CFG_POLYGON stuCenterPoint;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public byte[] byReserved;
}
