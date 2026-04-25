// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_SYSTEM_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_SYSTEM_INFO
{
	public uint dwSize;

	public bool bHasRTC;

	public int nRetMCUNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
	public NET_STRING_32_MCU_Version[] szMCUVersion;
}
