// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_OPERATE_FACERECONGNITION_GROUP

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_OPERATE_FACERECONGNITION_GROUP
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szGroupId;
}
