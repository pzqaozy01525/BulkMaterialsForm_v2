// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OPR_RIGHT_NEW

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OPR_RIGHT_NEW
{
	public uint dwSize;

	public uint dwID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string name;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string memo;

	public override string ToString()
	{
		return name;
	}
}
