// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORS_BYALIAS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORS_BYALIAS_INFO
{
	public int nChannel;

	public int nVideoStream;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public int nFlagCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_RECORD_SNAP_FLAG_TYPE[] emFlagsList;

	public uint nDriveNo;

	public uint nCluster;

	public int nMediaType;

	public int nPartition;

	public uint nLength;

	public uint nCutLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
	public string szFilePath;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szResvered;
}
