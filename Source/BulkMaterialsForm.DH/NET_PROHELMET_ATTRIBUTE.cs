// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_PROHELMET_ATTRIBUTE

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_PROHELMET_ATTRIBUTE
{
	public EM_WEARING_STATE emHasHat;

	public EM_CLOTHES_COLOR emHatColor;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szReserved;
}
