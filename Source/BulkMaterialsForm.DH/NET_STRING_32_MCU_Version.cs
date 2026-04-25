// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_STRING_32_MCU_Version

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_STRING_32_MCU_Version
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szMCUVersion;
}
