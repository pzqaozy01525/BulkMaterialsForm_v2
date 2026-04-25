// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADAR_ALARMPOINT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADAR_ALARMPOINT_INFO
{
	public EM_RADAR_POINTTYPE emPointType;

	public int nPointType;

	public int nRegionNumber;

	public EM_RADAR_OBJECTTYPE emObjectType;

	public int nTrackID;

	public int nDistance;

	public int nAngle;

	public int nSpeed;

	public int nLongitude;

	public int nLatitude;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szTrackerIP;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 488)]
	public byte[] byReserved;
}
