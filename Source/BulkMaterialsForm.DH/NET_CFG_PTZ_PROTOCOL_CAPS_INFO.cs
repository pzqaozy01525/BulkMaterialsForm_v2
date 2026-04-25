// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PTZ_PROTOCOL_CAPS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PTZ_PROTOCOL_CAPS_INFO
{
	public int nStructSize;

	public bool bPan;

	public bool bTile;

	public bool bZoom;

	public bool bIris;

	public bool bPreset;

	public bool bRemovePreset;

	public bool bTour;

	public bool bRemoveTour;

	public bool bPattern;

	public bool bAutoPan;

	public bool bAutoScan;

	public bool bAux;

	public bool bAlarm;

	public bool bLight;

	public bool bWiper;

	public bool bFlip;

	public bool bMenu;

	public bool bMoveRelatively;

	public bool bMoveAbsolutely;

	public bool bMoveDirectly;

	public bool bReset;

	public bool bGetStatus;

	public bool bSupportLimit;

	public bool bPtzDevice;

	public bool bIsSupportViewRange;

	public ushort wCamAddrMin;

	public ushort wCamAddrMax;

	public ushort wMonAddrMin;

	public ushort wMonAddrMax;

	public ushort wPresetMin;

	public ushort wPresetMax;

	public ushort wTourMin;

	public ushort wTourMax;

	public ushort wPatternMin;

	public ushort wPatternMax;

	public ushort wTileSpeedMin;

	public ushort wTileSpeedMax;

	public ushort wPanSpeedMin;

	public ushort wPanSpeedMax;

	public ushort wAutoScanMin;

	public ushort wAutoScanMax;

	public ushort wAuxMin;

	public ushort wAuxMax;

	public uint dwInterval;

	public uint dwType;

	public uint dwAlarmLen;

	public uint dwNearLightNumber;

	public uint dwFarLightNumber;

	public uint dwSupportViewRangeType;

	public uint dwSupportFocusMode;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public PTZ_PROTOCOL_CAPS_AUX[] szAuxs;

	public NET_CFG_PTZ_MOTION_RANGE stuPtzMotionRange;

	public NET_CFG_PTZ_LIGHTING_CONTROL stuPtzLightingControl;

	public bool bSupportPresetTimeSection;

	public bool bFocus;

	public NET_CFG_PTZ_AREA_SCAN stuPtzAreaScan;

	public NET_CFG_PTZ_PRIVACY_MASKING stuPtzPrivacyMasking;

	public NET_CFG_PTZ_MEASURE_DISTANCE stuPtzMeasureDistance;

	public bool bSupportPtzPatternOSD;

	public bool bSupportPtzRS485DetectOSD;

	public bool bSupportPTZCoordinates;

	public bool bSupportPTZZoom;

	public bool bDirectionDisplay;

	public uint dwZoomMax;

	public uint dwZoomMin;

	public NET_CFG_PTZ_MOVE_ABSOLUTELY_CAP stuMoveAbsolutely;

	public bool bMoveContinuously;

	public NET_CFG_PTZ_MOVE_CONTINUOUSLY_CAPS stuMoveContinuously;

	public int nUnSupportDirections;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public EM_PTZ_UNSUPPORT_DIRECTION[] emUnSupportDirections;

	public bool bSupportEptzLink;
}
