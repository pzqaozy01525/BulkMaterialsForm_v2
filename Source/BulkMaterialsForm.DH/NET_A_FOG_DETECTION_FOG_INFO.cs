// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_FOG_DETECTION_FOG_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_FOG_DETECTION_FOG_INFO
{
	public EM_FOG_LEVEL emFogLevel;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 508)]
	public byte[] byReserved;
}
