// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_DOFINDNUMBERSTAT

using System;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_DOFINDNUMBERSTAT
{
	public uint dwSize;

	public int nCount;

	public IntPtr pstuNumberStat;

	public int nBufferLen;

	public int nMinStayTime;
}
