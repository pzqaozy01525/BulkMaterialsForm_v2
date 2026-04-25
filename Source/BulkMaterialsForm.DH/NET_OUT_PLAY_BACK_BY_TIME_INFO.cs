// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_PLAY_BACK_BY_TIME_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_PLAY_BACK_BY_TIME_INFO
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] bReserved;
}
