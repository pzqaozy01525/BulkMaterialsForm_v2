// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_TRAFFICSTARTFINDSTAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_TRAFFICSTARTFINDSTAT
{
	public uint dwSize;

	public NET_TIME stStartTime;

	public NET_TIME stEndTime;

	public int nWaittime;

	public int nChannelCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public int[] nChannels;

	public int nLaneCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public int[] nLanes;

	public int nClassType;

	public EM_GRANULARITY_STARTFIND_TYPE emGranularity;

	public EM_STARTFIND_DIRECTION emDirection;
}
