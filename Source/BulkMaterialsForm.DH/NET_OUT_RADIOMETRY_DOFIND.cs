// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_RADIOMETRY_DOFIND

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_RADIOMETRY_DOFIND
{
	public uint dwSize;

	public int nFound;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
	public NET_RADIOMETRY_QUERY[] stInfo;
}
