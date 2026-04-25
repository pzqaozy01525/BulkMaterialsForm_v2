// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_IXRAY_PACKAGE_MANAGER_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_IXRAY_PACKAGE_MANAGER_CAPS
{
	public uint dwSize;

	public int nObjectTypes;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public EM_XRAY_OBJECT_TYPE[] emObjectType;
}
