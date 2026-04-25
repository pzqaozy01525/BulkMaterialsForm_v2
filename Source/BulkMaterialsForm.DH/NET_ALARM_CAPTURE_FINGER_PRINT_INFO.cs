// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_CAPTURE_FINGER_PRINT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_CAPTURE_FINGER_PRINT_INFO
{
	public uint dwSize;

	public int nChannelID;

	public NET_TIME stuTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szReaderID;

	public int nPacketLen;

	public int nPacketNum;

	public IntPtr szFingerPrintInfo;

	public bool bCollectResult;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szCardNo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;
}
