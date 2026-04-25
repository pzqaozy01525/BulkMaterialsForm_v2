// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.MEDIAFILE_TRAFFICCAR_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct MEDIAFILE_TRAFFICCAR_INFO
{
	public uint ch;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFilePath;

	public uint size;

	public NET_TIME starttime;

	public NET_TIME endtime;

	public uint nWorkDirSN;

	public byte nFileType;

	public byte bHint;

	public byte bDriveNo;

	public byte bReserved2;

	public uint nCluster;

	public byte byPictureType;

	public byte byVideoStream;

	public byte byPartition;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
	public byte[] bReserved;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szPlateType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szPlateColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szVehicleColor;

	public int nSpeed;

	public int nEventsNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public int[] nEvents;

	public uint dwBreakingRule;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szVehicleSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szChannelName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
	public string szMachineName;

	public int nSpeedUpperLimit;

	public int nSpeedLowerLimit;

	public int nGroupID;

	public byte byCountInGroup;

	public byte byIndexInGroup;

	public byte byLane;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 21)]
	public byte[] bReserved1;

	public NET_TIME stSnapTime;

	public int nDirection;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szMachineAddress;

	public long sizeEx;
}
