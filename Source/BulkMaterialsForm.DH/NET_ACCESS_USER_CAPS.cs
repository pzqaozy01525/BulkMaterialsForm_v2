// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_ACCESS_USER_CAPS

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_ACCESS_USER_CAPS
{
	public int nMaxInsertRate;

	public int nMaxUsers;

	public int nMaxFingerPrintsPerUser;

	public int nMaxCardsPerUser;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
	public byte[] byReserved;
}
