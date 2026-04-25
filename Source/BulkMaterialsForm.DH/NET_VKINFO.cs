// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_VKINFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_VKINFO
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVKID;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
	public string szVK;

	public EM_ALGORITHM_TYPE emAlgorithmType;

	public int nRetVKIDLen;

	public int nRetVKLen;

	public EM_IS_ENCRYPT emIsEncrypt;

	public EM_IS_CURRENT_VK emIsCurrent;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 492)]
	public byte[] szReserved;
}
