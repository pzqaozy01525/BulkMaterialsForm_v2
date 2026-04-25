// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_ACCESS_USER_SERVICE_GET

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_ACCESS_USER_SERVICE_GET
{
	public uint dwSize;

	public int nMaxRetNum;

	public IntPtr pUserInfo;

	public IntPtr pFailCode;
}
