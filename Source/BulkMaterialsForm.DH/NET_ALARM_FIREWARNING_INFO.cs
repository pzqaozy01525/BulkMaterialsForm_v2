// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_FIREWARNING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_FIREWARNING_INFO
{
	public int nPresetId;

	public int nState;

	public NET_RECT stBoundingBox;

	public int nTemperatureUnit;

	public float fTemperature;

	public uint nDistance;

	public NET_GPS_POINT stGpsPoint;

	public int nChannel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] reserved;
}
