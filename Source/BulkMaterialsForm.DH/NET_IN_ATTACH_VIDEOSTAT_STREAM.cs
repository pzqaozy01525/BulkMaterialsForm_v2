// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTACH_VIDEOSTAT_STREAM

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTACH_VIDEOSTAT_STREAM
{
	public uint dwSize;

	public int nVideoChannel;

	public EM_STAT_GRANULARITY emGranularity;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 4)]
	public string szReserved1;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRuleType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szStartTime;

	public fVideoStatStreamCallBack cbVideoStatStream;

	public IntPtr dwUser;

	public ushort nCycle;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 6)]
	public string szReserved2;
}
