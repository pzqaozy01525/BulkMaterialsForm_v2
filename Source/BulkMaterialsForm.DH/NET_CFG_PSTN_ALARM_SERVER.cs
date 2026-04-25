// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CFG_PSTN_ALARM_SERVER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CFG_PSTN_ALARM_SERVER
{
	public bool bNeedReport;

	public int nServerCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public byte[] byDestination;
}
