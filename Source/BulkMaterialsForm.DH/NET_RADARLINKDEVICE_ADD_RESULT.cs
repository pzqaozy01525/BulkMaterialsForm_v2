// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADARLINKDEVICE_ADD_RESULT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADARLINKDEVICE_ADD_RESULT
{
	public NET_EM_RADARLINKDEVICE_ADD_ERRORCODE emErrorCode;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 252)]
	public byte[] byReserved;
}
