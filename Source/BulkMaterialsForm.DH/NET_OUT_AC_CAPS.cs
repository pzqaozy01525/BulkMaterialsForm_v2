// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_AC_CAPS

namespace BulkMaterialsForm.DH;

public struct NET_OUT_AC_CAPS
{
	public uint dwSize;

	public NET_AC_CAPS stuACCaps;

	public NET_ACCESS_USER_CAPS stuUserCaps;

	public NET_ACCESS_CARD_CAPS stuCardCaps;

	public NET_ACCESS_FINGERPRINT_CAPS stuFingerprintCaps;

	public NET_ACCESS_FACE_CAPS stuFaceCaps;

	public NET_ACCESS_IRIS_CAPS stuIrisCaps;
}
