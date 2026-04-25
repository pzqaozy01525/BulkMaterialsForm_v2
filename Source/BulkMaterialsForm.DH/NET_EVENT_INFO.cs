// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_EVENT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_EVENT_INFO
{
	public int nEvent;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
	public EM_OBJECT_TYPE[] arrayObejctType;

	public int nObjectCount;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
