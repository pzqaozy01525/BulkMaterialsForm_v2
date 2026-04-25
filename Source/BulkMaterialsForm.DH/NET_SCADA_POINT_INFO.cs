// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_SCADA_POINT_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_SCADA_POINT_INFO
{
	public uint dwSize;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szDevName;

	public int nYX;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public uint[] anYX;

	public int nYC;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
	public float[] afYC;
}
