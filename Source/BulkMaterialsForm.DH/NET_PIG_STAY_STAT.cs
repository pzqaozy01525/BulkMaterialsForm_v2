// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PIG_STAY_STAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PIG_STAY_STAT
{
	public NET_TIME stuEnterTime;

	public NET_TIME stuExitTime;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 208)]
	public string szReserved;
}
