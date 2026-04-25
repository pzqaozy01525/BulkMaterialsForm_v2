// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEV_IPC_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEV_IPC_INFO
{
	public int nTypeCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_IPC_TYPE[] bSupportTypes;
}
