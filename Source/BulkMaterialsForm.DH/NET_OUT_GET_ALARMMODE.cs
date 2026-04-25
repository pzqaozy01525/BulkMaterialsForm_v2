// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_GET_ALARMMODE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_GET_ALARMMODE
{
	public uint dwSize;

	public int nArmModeRet;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_ARMMODE_INFO[] stuArmMode;

	public int nArmModeRetEx;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public NET_ARMMODE_INFO[] stuArmModeEx;
}
