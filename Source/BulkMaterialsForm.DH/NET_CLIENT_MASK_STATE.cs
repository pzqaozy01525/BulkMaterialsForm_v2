// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CLIENT_MASK_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CLIENT_MASK_STATE
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public byte[] dwAlarmState;
}
