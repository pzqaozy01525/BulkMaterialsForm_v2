// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PRODUCTION_DEFNITION

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PRODUCTION_DEFNITION
{
	public uint dwSize;

	public int nVideoInChannel;

	public int nVideoOutChannel;

	public int nRemoteDecChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szVendor;

	public int nOEMVersion;

	public int nMajorVerion;

	public int nMinorVersion;

	public int nRevision;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szWebVerion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szDefLanguage;

	public NET_TIME stuBuildDateTime;

	public int nAudioInChannel;

	public int nAudioOutChannel;

	public bool bGeneralRecord;

	public bool bLocalStore;

	public bool bRemoteStore;

	public bool bLocalurgentStore;

	public bool bRealtimeCompress;

	public uint dwVideoStandards;

	public int nDefVideoStandard;

	public int nMaxExtraStream;

	public int nRemoteRecordChannel;

	public int nRemoteSnapChannel;

	public int nRemoteVideoAnalyseChannel;

	public int nRemoteTransmitChannel;

	public int nRemoteTransmitFileChannel;

	public int nStreamTransmitChannel;

	public int nStreamReadChannel;

	public int nMaxStreamSendBitrate;

	public int nMaxStreamRecvBitrate;

	public bool bCompressOldFile;

	public bool bRaid;

	public int nMaxPreRecordTime;

	public bool bPtzAlarm;

	public bool bPtz;

	public bool bATM;

	public bool b3G;

	public bool bNumericKey;

	public bool bShiftKey;

	public bool bCorrectKeyMap;

	public bool bNewATM;

	public bool bDecoder;

	public NET_DEV_DECODER_INFO stuDecoderInfo;

	public int nVideoOutputCompositeChannels;

	public bool bSupportedWPS;

	public int nVGAVideoOutputChannels;

	public int nTVVideoOutputChannels;

	public int nMaxRemoteInputChannels;

	public int nMaxMatrixInputChannels;

	public int nMaxRoadWays;

	public int nMaxParkingSpaceScreen;

	public int nPtzHorizontalAngleMin;

	public int nPtzHorizontalAngleMax;

	public int nPtzVerticalAngleMin;

	public int nPtzVerticalAngleMax;

	public bool bPtzFunctionMenu;

	public bool bLightingControl;

	public uint dwLightingControlMode;

	public int nNearLightNumber;

	public int nFarLightNumber;

	public bool bFocus;

	public bool bIris;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szPtzProtocolList;

	public bool bRainBrushControl;

	public int nBrushNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public int[] nLowerMatrixInputChannels;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public int[] nLowerMatrixOutputChannels;

	public bool bSupportVideoAnalyse;

	public bool bSupportIntelliTracker;

	public uint nSupportBreaking;

	public uint nSupportBreaking1;

	public NET_PD_VIDEOANALYSE stuVideoAnalyse;

	public bool bTalkTransfer;

	public bool bCameraAttribute;

	public bool bPTZFunctionViaApp;

	public bool bAudioProperties;

	public bool bIsCameraIDOsd;

	public bool bIsPlaceOsd;

	public uint nMaxGeographyTitleLine;

	public EM_AUDIO_CHANNEL_TYPE emAudioChannel;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVendorAbbr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szTypeVersion;

	public bool bIsVideoNexus;

	public EM_WLAN_SCAN_AND_CONFIG_TYPE emWlanScanAndConfig;

	public bool bSupportLensMasking;
}
