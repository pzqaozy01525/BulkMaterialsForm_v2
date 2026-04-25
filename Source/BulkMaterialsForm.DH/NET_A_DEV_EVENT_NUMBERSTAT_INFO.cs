// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_DEV_EVENT_NUMBERSTAT_INFO

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_DEV_EVENT_NUMBERSTAT_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string bReserved2;

	public double PTS;

	public NET_TIME_EX UTC;

	public int nEventID;

	public int nNumber;

	public int nUpperLimit;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public byte bEventAction;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
	public byte[] bReserved1;

	public byte byImageIndex;

	public int nEnteredNumber;

	public int nExitedNumber;

	public uint dwSnapFlagMask;

	public uint nOccurrenceCount;

	public NET_EVENT_INTELLI_COMM_INFO stuIntelliCommInfo;

	public uint nAreaID;

	public bool bIsCompliant;

	public EM_NUMBER_STAT_TYPE emType;

	public IntPtr pstuImageInfo;

	public int nImageInfoNum;

	public int nPassedNumber;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 800)]
	public byte[] bReserved;
}
