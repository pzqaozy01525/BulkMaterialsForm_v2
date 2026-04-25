// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_DEFENSE_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_DEFENSE_STATE
{
	public EM_DEFENSE_STATE emState;

	public int nDefenseID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
	public string szReserved;
}
