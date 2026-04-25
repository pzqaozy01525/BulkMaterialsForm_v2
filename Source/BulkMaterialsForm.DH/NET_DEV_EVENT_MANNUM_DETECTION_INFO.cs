// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_MANNUM_DETECTION_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_MANNUM_DETECTION_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public byte[] bReserved1;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nAction;

	public int nManListCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_MAN_NUM_LIST_INFO[] stuManList;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public uint nAreaID;

	public uint nPrevNumber;

	public uint nCurrentNumber;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public byte[] szSourceID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szRuleName;

	public EM_EVENT_DETECT_TYPE emDetectType;

	public uint nAlertNum;

	public int nAlarmType;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 784)]
	public string szReversed;
}
