// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_AV_CFG_Locales

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

[StructLayout(LayoutKind.Sequential, Pack = 4)]
public struct NET_AV_CFG_Locales
{
	public int nStructSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
	public string szTimeFormat;

	public bool bDSTEnable;

	public AV_CFG_DSTTime stuDstStart;

	public AV_CFG_DSTTime stuDstEnd;

	public bool bWeekEnable;

	public byte ucWorkDay;
}
