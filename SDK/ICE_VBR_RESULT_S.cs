using System.Runtime.InteropServices;

namespace BulkMaterialsForm.SDK;

public struct ICE_VBR_RESULT_S
{
	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 20)]
	public string szLogName;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 88)]
	public string reserve;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.R4)]
	public float[] fResFeature;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
	public uint[] iReserved;
}
