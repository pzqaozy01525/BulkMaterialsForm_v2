// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_NONMOTOR_STAY_STAT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_NONMOTOR_STAY_STAT
{
	public NET_TIME stuEnterTime;

	public NET_TIME stuExitTime;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] reserved;
}
