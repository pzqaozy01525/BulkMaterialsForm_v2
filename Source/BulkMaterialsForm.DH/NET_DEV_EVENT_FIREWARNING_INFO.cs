// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_EVENT_FIREWARNING_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_EVENT_FIREWARNING_INFO
{
	public int nChannelID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szName;

	public NET_EVENT_FILE_INFO stuFileInfo;

	public int nAction;

	public uint nFSID;

	public EM_FIREWARNING_PIC_TYPE emPicType;

	public bool bIsLeaveFireDetect;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1012)]
	public byte[] byReserved;
}
