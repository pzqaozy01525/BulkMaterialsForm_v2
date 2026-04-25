// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_MSG_OBJECT_SUPPLEMENT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct NET_A_MSG_OBJECT_SUPPLEMENT
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
	public string szObjectUUID;

	public uint nMuckHide;

	public uint nCarryType;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 248)]
	public string szReserved;
}
