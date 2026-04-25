// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OLDLOG

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OLDLOG
{
	public NET_LOG_ITEM stuLog;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 48)]
	public byte[] bReserved;
}
