// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_TYPE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_TYPE
{
	public bool bIsAlarmEvent;

	public bool bIsViolation;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
	public byte[] byReserved;
}
