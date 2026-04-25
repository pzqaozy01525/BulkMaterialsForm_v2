// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SOURCE_STREAM_ENCRYPT

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SOURCE_STREAM_ENCRYPT
{
	public EM_ENCRYPT_LEVEL emEncryptLevel;

	public EM_ENCRYPT_ALGORITHM_TYPE emAlgorithm;

	public EM_KEY_EXCHANGE_TYPE emExchange;

	public bool bUnvarnished;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1032)]
	public string szPSK;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)]
	public byte[] byReserved;
}
