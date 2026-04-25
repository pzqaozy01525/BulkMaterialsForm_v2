// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_BURN_CASE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_BURN_CASE_INFO
{
	public uint dwSize;

	public int nChannel;

	public NET_TIME stuStartTime;

	public NET_TIME stuEndTime;

	public int nIndex;

	public int nCode;

	public int nDiscNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szPlace;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szInvestigator;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
	public string szXyfs;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szMemo;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVideoName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szRecorder;
}
