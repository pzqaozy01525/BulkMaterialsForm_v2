// Decompiled from: BulkMaterialsForm.exe
// Namespace: BulkMaterialsForm.DH
// Type: BulkMaterialsForm.DH.NET_MAN_TEMP_INFO

using System.Runtime.InteropServices;

namespace BulkMaterialsForm.DH;

public struct NET_MAN_TEMP_INFO
{
	public uint nObjectID;

	public NET_RECT stRect;

	public double dbHighTemp;

	public uint nTempUnit;

	public bool bIsOverTemp;

	public bool bIsUnderTemp;

	public uint nOffset;

	public uint nLength;

	public EM_MASK_DETECT_RESULT_TYPE emMaskDetectResult;

	[MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
	public byte[] byReserved;
}
