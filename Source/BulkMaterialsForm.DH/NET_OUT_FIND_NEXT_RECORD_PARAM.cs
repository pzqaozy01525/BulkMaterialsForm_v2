// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_FIND_NEXT_RECORD_PARAM

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_FIND_NEXT_RECORD_PARAM
{
	public uint dwSize;

	public IntPtr pRecordList;

	public int nMaxRecordNum;

	public int nRetRecordNum;
}
