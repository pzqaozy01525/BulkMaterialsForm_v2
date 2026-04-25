// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_XRAY_OBJECT_UPLOAD_RULE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_XRAY_OBJECT_UPLOAD_RULE
{
	public bool bUploadEnable;

	public uint nSimilarity;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public byte[] byReserved;
}
