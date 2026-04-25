// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PROFILE_ALARM_TRANSMIT_CLOUDINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PROFILE_ALARM_TRANSMIT_CLOUDINFO
{
	public int nVideoLinkChannel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] szReserved;
}
