// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_LOGIN_WITH_HIGHLEVEL_SECURITY
{
	public uint dwSize;

	public NET_DEVICEINFO_Ex stuDeviceInfo;

	public int nError;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 132)]
	public byte[] byReserved;
}
