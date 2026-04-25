// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ACCESS_FINGERPRINT_SERVICE_GET
{
	public uint dwSize;

	public int nRetFingerPrintCount;

	public int nSinglePacketLength;

	public int nDuressIndex;

	public int nMaxFingerDataLength;

	public int nRetFingerDataLength;

	public IntPtr pbyFingerData;

	public NET_TIME stuUpdateTime;
}
