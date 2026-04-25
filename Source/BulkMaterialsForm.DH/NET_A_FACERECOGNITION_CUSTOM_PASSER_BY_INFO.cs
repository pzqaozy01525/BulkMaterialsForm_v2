// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_A_FACERECOGNITION_CUSTOM_PASSER_BY_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_A_FACERECOGNITION_CUSTOM_PASSER_BY_INFO
{
	public int nStorageAddrChannel;

	public int nStoragePresetID;

	public NET_TIME stuStorageTime;

	public NET_TIME stuLastAppearTime;

	public int nLastAppearAddrChannel;

	public int nLastAppearPresetID;

	public uint nOccurrenceNumber;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1020)]
	public string szReserved;
}
