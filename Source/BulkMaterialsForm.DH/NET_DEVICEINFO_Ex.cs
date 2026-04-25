// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEVICEINFO_Ex

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEVICEINFO_Ex
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string sSerialNumber;

	public int nAlarmInPortNum;

	public int nAlarmOutPortNum;

	public int nDiskNum;

	public EM_NET_DEVICE_TYPE nDVRType;

	public int nChanNum;

	public byte byLimitLoginTime;

	public byte byLeftLogTimes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved;

	public int nLockLeftTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public byte[] Reserved;
}
