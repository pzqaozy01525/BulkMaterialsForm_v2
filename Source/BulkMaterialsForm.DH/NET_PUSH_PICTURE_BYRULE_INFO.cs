// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PUSH_PICTURE_BYRULE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PUSH_PICTURE_BYRULE_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szFileID;

	public uint nOffset;

	public uint nLength;

	public NET_ANALYSE_RULE stuRuleInfo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szUserDefineData;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szModelUrl;

	public NET_REMOTE_STREAM_INFO stuRemoteStreamInfo;

	public uint nDetectType;

	public int nPicUrlNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32768)]
	public string szPicUrl;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] byReserved;
}
