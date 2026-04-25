// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_IN_FIND_RECORD_PARAM

using System;

namespace BulkMaterialsForm.DH;

public struct NET_IN_FIND_RECORD_PARAM
{
	public uint dwSize;

	public EM_NET_RECORD_TYPE emType;

	public IntPtr pQueryCondition;
}
