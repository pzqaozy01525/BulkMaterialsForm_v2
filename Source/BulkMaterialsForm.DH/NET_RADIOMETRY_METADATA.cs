// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_RADIOMETRY_METADATA

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_RADIOMETRY_METADATA
{
	public int nHeight;

	public int nWidth;

	public int nChannel;

	public NET_TIME stTime;

	public int nLength;

	[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
	public string szSensorType;

	public int nUnzipParamR;

	public int nUnzipParamB;

	public int nUnzipParamF;

	public int nUnzipParamO;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
	public byte[] Reserved;
}
