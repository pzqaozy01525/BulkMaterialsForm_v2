// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_PTZ_LOCATION_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_PTZ_LOCATION_INFO
{
	public int nChannelID;

	public int nPTZPan;

	public int nPTZTilt;

	public int nPTZZoom;

	public byte bState;

	public byte bAction;

	public byte bFocusState;

	public byte bEffectiveInTimeSection;

	public int nPtzActionID;

	public uint dwPresetID;

	public float fFocusPosition;

	public byte bZoomState;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved;

	public uint dwSequence;

	public uint dwUTC;

	public EM_DH_PTZ_PRESET_STATUS emPresetStatus;

	public int nZoomValue;

	public NET_PTZSPACE_UNNORMALIZED stuAbsPosition;

	public int nFocusMapValue;

	public int nZoomMapValue;

	public EM_DH_PTZ_PAN_TILT_STATUS emPanTiltStatus;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 696)]
	public string reserved;
}
