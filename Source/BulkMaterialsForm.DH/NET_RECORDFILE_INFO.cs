// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RECORDFILE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RECORDFILE_INFO
{
	public uint ch;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 124)]
	public string filename;

	public uint framenum;

	public uint size;

	public NET_TIME starttime;

	public NET_TIME endtime;

	public uint driveno;

	public uint startcluster;

	public byte nRecordFileType;

	public byte bImportantRecID;

	public byte bHint;

	public byte bRecType;
}
