// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CB_BACKUPTASK_STATE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CB_BACKUPTASK_STATE
{
	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public NET_BACKUP_STATES_INFO[] stuStates;

	public int nStatesNum;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1020)]
	public string bReserved;
}
