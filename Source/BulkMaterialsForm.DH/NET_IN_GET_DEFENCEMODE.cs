// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_GET_DEFENCEMODE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_IN_GET_DEFENCEMODE
{
	public uint dwSize;

	public int nDefenceNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public int[] anDefence;
}
