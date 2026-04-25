// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MATRIX_CARD

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MATRIX_CARD
{
	public uint dwSize;

	public bool bEnable;

	public uint dwCardType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szInterface;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szAddress;

	public int nPort;

	public int nDefinition;

	public int nVideoInChn;

	public int nAudioInChn;

	public int nVideoOutChn;

	public int nAudioOutChn;

	public int nVideoEncChn;

	public int nAudioEncChn;

	public int nVideoDecChn;

	public int nAudioDecChn;

	public int nStauts;

	public int nCommPorts;

	public int nVideoInChnMin;

	public int nVideoInChnMax;

	public int nAudioInChnMin;

	public int nAudioInChnMax;

	public int nVideoOutChnMin;

	public int nVideoOutChnMax;

	public int nAudioOutChnMin;

	public int nAudioOutChnMax;

	public int nVideoEncChnMin;

	public int nVideoEncChnMax;

	public int nAudioEncChnMin;

	public int nAudioEncChnMax;

	public int nVideoDecChnMin;

	public int nVideoDecChnMax;

	public int nAudioDecChnMin;

	public int nAudioDecChnMax;

	public int nCascadeChannels;

	public int nCascadeChannelBitrate;

	public int nAlarmInChnCount;

	public int nAlarmInChnMin;

	public int nAlarmInChnMax;

	public int nAlarmOutChnCount;

	public int nAlarmOutChnMin;

	public int nAlarmOutChnMax;

	public int nVideoAnalyseChnCount;

	public int nVideoAnalyseChnMin;

	public int nVideoAnalyseChnMax;

	public int nCommPortMin;

	public int nCommPortMax;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVersion;

	public NET_TIME stuBuildTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szBIOSVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szMAC;
}
