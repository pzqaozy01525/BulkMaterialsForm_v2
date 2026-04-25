// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CUSTOM_PERSON_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_CUSTOM_PERSON_INFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szPersonInfo;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 124)]
	public byte[] byReserved;
}
