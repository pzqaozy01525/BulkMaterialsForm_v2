// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_ENCODE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_ENCODE_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szChnName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_CFG_VIDEOENC_OPT[] stuMainStream;

	public int nValidCountMainStream;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_CFG_VIDEOENC_OPT[] stuExtraStream;

	public int nValidCountExtraStream;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_CFG_VIDEOENC_OPT[] stuSnapFormat;

	public int nValidCountSnapFormat;

	public uint dwCoverAbilityMask;

	public uint dwCoverEnableMask;

	public NET_CFG_VIDEO_COVER stuVideoCover;

	public NET_CFG_OSD_INFO stuChnTitle;

	public NET_CFG_OSD_INFO stuTimeTitle;

	public NET_CFG_COLOR_INFO stuVideoColor;

	public EM_CFG_AUDIO_FORAMT emAudioFormat;

	public int nProtocolVer;
}
