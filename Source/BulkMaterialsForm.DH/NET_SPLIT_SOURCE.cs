// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SPLIT_SOURCE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SPLIT_SOURCE
{
	public uint dwSize;

	public bool bEnable;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szIp;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szUser;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
	public string szPwd;

	public int nPort;

	public int nChannelID;

	public int nStreamType;

	public int nDefinition;

	public EM_DEVICE_PROTOCOL emProtocol;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevName;

	public int nVideoChannel;

	public int nAudioChannel;

	public bool bDecoder;

	public byte byConnType;

	public byte byWorkMode;

	public short wListenPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevIpEx;

	public byte bySnapMode;

	public byte byManuFactory;

	public byte byDeviceType;

	public byte byDecodePolicy;

	public uint dwHttpPort;

	public uint dwRtspPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szChnName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szMcastIP;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDeviceID;

	public bool bRemoteChannel;

	public uint nRemoteChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevClass;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szMainStreamUrl;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szExtraStreamUrl;

	public int nUniqueChannel;

	public NET_CASCADE_AUTHENTICATOR stuCascadeAuth;

	public int nHint;

	public int nOptionalMainUrlCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2080)]
	public byte[] szOptionalMainUrls;

	public int nOptionalExtraUrlCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2080)]
	public byte[] szOptionalExtraUrls;

	public int nInterval;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szUserEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPwdEx;

	public EM_SRC_PUSHSTREAM_TYPE emPushStream;

	public NET_RECT stuSRect;

	public NET_SOURCE_STREAM_ENCRYPT stuSourceStreamEncrypt;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szSerialNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szCaption;

	public bool bUserStreamUrlEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szMainStreamUrlEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szExtraStreamUrlEx;
}
