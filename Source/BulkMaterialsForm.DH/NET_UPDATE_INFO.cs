// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_UPDATE_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_UPDATE_INFO
{
	public EM_UPDATE_TYPE emType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szName;

	public EM_SPACE_TYPE emBeforeUpdateType;

	public EM_SPACE_TYPE emAfterUpdateType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szResvered;
}
