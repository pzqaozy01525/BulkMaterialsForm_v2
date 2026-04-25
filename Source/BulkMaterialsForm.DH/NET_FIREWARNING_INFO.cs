// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_FIREWARNING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_FIREWARNING_INFO
{
	public int nPresetId;

	public NET_RECT stuBoundingBox;

	public int nTemperatureUnit;

	public float fTemperature;

	public uint nDistance;

	public NET_GPS_POINT stuGpsPoint;

	public NET_PTZ_POSITION_UNIT stuPTZPosition;

	public float fAltitude;

	public uint nThermoHFOV;

	public uint nThermoVFOV;

	public uint nFSID;

	public NET_FIRING_GPS_INFO stuFiringGPS;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 148)]
	public byte[] reserved;
}
