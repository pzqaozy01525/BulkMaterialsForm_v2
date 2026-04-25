// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OPEN_INTELLI_USER_DATA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OPEN_INTELLI_USER_DATA_INFO
{
	public int nAlarmId;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
	public string szReserved;
}
