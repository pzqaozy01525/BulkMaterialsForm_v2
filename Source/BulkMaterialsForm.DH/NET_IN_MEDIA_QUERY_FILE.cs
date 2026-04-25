// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_MEDIA_QUERY_FILE

using System;
using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_MEDIA_QUERY_FILE
{
	public uint dwSize;

	public IntPtr szDirs;

	public int nMediaType;

	public int nChannelID;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nEventLists;

	public int nEventCount;

	public byte byVideoStream;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
	public byte[] bReserved;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_RECORD_SNAP_FLAG_TYPE[] emFalgLists;

	public int nFalgCount;

	public NET_RECORD_CARD_INFO stuCardInfo;

	public int nUserCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] szUserName;

	public EM_RESULT_ORDER_TYPE emResultOrder;

	public bool bTime;

	public EM_COMBINATION_MODE emCombination;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public NET_EVENT_INFO[] stuEventInfo;

	public int nEventInfoCount;

	public bool bOnlySupportRealUTC;

	public NET_TIME stuStartTimeRealUTC;

	public NET_TIME stuEndTimeRealUTC;
}
