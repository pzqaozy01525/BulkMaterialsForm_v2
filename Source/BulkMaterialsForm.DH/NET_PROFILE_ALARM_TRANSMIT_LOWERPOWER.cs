// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PROFILE_ALARM_TRANSMIT_LOWERPOWER

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PROFILE_ALARM_TRANSMIT_LOWERPOWER
{
	public int nPercent;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szReserved;
}
