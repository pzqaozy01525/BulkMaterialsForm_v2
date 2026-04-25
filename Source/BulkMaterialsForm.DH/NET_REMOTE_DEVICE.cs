// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_REMOTE_DEVICE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_REMOTE_DEVICE
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

	public int nDefinition;

	public EM_DEVICE_PROTOCOL emProtocol;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevName;

	public int nVideoInputChannels;

	public int nAudioInputChannels;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevClass;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDevType;

	public int nHttpPort;

	public int nMaxVideoInputCount;

	public int nRetVideoInputCount;

	public IntPtr pstuVideoInputs;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMachineAddress;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szSerialNo;

	public int nRtspPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPwdEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szVendorAbbr;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSoftwareVersion;

	public NET_TIME stuActivationTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szMac;

	public int nHttpsPort;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] byReserved;
}
