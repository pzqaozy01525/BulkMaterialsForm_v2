// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_CTRL_RECORDSET_INSERT_IN

using System;

namespace BulkMaterialsForm.DH;

public struct NET_CTRL_RECORDSET_INSERT_IN
{
	public uint dwSize;

	public EM_NET_RECORD_TYPE emType;

	public IntPtr pBuf;

	public int nBufLen;
}
