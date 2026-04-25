// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.DEVICE_NET_INFO_EX

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct DEVICE_NET_INFO_EX
{
	public int iIPVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szIP;

	public int nPort;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSubmask;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGateway;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
	public string szMac;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDeviceType;

	public byte byManuFactory;

	public byte byDefinition;

	public byte bDhcpEn;

	public byte byReserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 88)]
	public string verifyData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szSerialNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szDevSoftVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szDetailType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVendor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPassWord;

	public ushort nHttpPort;

	public ushort wVideoInputCh;

	public ushort wRemoteVideoInputCh;

	public ushort wVideoOutputCh;

	public ushort wAlarmInputCh;

	public ushort wAlarmOutputCh;

	public bool bNewWordLen;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNewPassWord;

	public byte byInitStatus;

	public byte byPwdResetWay;

	public byte bySpecialAbility;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNewDetailType;

	public bool bNewUserName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szNewUserName;

	public byte byPwdFindVersion;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
	public string szDeviceID;

	public uint dwUnLoginFuncMask;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szMachineGroup;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
	public byte[] cReserved;
}
