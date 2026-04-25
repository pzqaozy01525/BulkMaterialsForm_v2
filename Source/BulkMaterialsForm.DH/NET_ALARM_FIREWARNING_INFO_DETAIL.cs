// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ALARM_FIREWARNING_INFO_DETAIL

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ALARM_FIREWARNING_INFO_DETAIL
{
	public int nChannel;

	public int nWarningInfoCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
	public NET_FIREWARNING_INFO[] stuFireWarningInfo;

	public NET_EVENT_INFO_EXTEND stuEventInfoEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] reserved;
}
