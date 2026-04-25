// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.AV_CFG_DSTTime

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct AV_CFG_DSTTime
{
	public int nStructSize;

	public int nYear;

	public int nMonth;

	public int nWeek;

	public int nDay;

	public int nHour;

	public int nMinute;
}
