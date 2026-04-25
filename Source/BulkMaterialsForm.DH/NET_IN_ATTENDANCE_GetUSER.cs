// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_ATTENDANCE_GetUSER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_ATTENDANCE_GetUSER
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szUserID;
}
