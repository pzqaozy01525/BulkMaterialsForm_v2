// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_SET_FILE_ALIAS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_SET_FILE_ALIAS_INFO
{
	public uint dwSize;

	public int nChannel;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public int nVideoStream;

	public int nFlagCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_RECORD_SNAP_FLAG_TYPE[] emFlagsList;

	public int nMediaType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szRecordAlias;
}
