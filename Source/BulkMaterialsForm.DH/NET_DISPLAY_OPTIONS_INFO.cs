// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DISPLAY_OPTIONS_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DISPLAY_OPTIONS_INFO
{
	public bool bIsSwitchDisplayed;

	public bool bIsScrollDisplaySwitch;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 120)]
	public byte[] byReserved;
}
