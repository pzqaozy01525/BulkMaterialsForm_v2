// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_OUT_SCADA_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_OUT_SCADA_INFO
{
	public uint dwSize;

	public int nPointInfoNum;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
	public NET_SCADA_POINT_INFO[] stuPointInfo;
}
