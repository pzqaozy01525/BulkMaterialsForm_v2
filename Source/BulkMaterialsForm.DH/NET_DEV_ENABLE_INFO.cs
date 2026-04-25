// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_ENABLE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_ENABLE_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public uint[] IsFucEnable;
}
